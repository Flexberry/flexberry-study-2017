using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using ICSSoft.STORMNET.FunctionalLanguage;
    using ICSSoft.STORMNET.FunctionalLanguage.SQLWhere;

    using IIS.АСУ_Склад;

    class Program
    {
        /// <summary>
        /// Точка входа в приложение. Методы, которые описаны ниже, можно по очереди вызывать отсюда и проверять их работу.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ReadFromSeveralBases();
            Console.ReadKey();
        }

        /// <summary>
        /// Создание одного объекта данных в базе данных.
        /// </summary>
        static void CreateObject()
        {
            var t = new Товар() { Название = "Гвозди", ЕдиницаИзмерения = "кг", Описание = "Железные гвозди", Цена = 150, КодТовара = 33 };
            var ds = (SQLDataService)DataServiceProvider.DataService;
            try
            {
                ds.UpdateObject(t);
                Console.WriteLine("ОК\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Ошибка: {0}\n", e.Message));
            }
        }

        /// <summary>
        /// Чтение объекта данных по первичному ключу и последующее удаление данного объекта данных из базы данных.
        /// </summary>
        /// <remarks>
        /// 1. Нужно исправить значение первичного ключа в коде на актуальное, чтобы вычитать реально существующий объект из базы данных
        /// 2. Если на соответствующий объект ссылаются объекты в базе данных, то объект может не удалиться, так как сработают ограничения целостности в базе данных.
        ///    Такой случай подразумевает реализовацию каскадного удаления данных в бизнес-серверах.
        /// </remarks>
        static void DeleteObject()
        {
            try
            {
                var ds = (SQLDataService)DataServiceProvider.DataService;
                var t = new Товар();

                //Требуется заменить значение первичного ключа на актуальное из базы данных.
                t.SetExistObjectPrimaryKey("27486786-648C-419B-B0BF-F8BA739ABF58");
                ds.LoadObject(t);

                Console.WriteLine($"Название: {t.Название}\n");

                t.SetStatus(ObjectStatus.Deleted);
                ds.UpdateObject(t);
                Console.WriteLine("Удален\n");

            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Ошибка: {0}\n", e.Message));
            }
        }

        /// <summary>
        /// Создание нескольких объектов данных в базе данных за одну операцию.
        /// </summary>
        /// <remarks>
        /// Порядок добавления и изменения объектов данных сервис данных как правило контролирует сам, но есть ряд случаев, когда необходимо 
        /// соблюдать оперделенный порядок передачи объектов данных в соответствующий массив:
        ///   - Наличие циклов в графе типов
        ///   - Удаление объекта и его мастера в одной транзакции
        ///   - Ситуация, когда агрегатор и детейл имеют мастера одного типа
        ///   - Другие варианты при наличии связанных объектов с разными статусами, т.е. когда часть объектов добавляется, часть - обновляется, часть - удаляется
        /// </remarks>
        static void CreateObjects()
        {
            var t = new Товар() { Название = "Батон", ЕдиницаИзмерения = "шт", Описание = "Вкусняшка", Цена = 22, КодТовара = 123 };
            var t2 = new Товар() { Название = "Гвозди", ЕдиницаИзмерения = "кг", Описание = "Железные гвозди", Цена = 150, КодТовара = 33 };
            var s = new Сотрудник() { Фамилия = "Сидоров", Имя = "Сидор", ТабельныйНомер = 345 };
            var s2 = new Сотрудник() { Фамилия = "Петров", Имя = "Петр", ТабельныйНомер = 777 };
            var skl = new Склад() { Номер = 15, Адрес = "ул. Ленина, 49", Менеджер = s };
            var skl2 = new Склад() { Номер = 28, Адрес = "ул. Промышленная, 88", Менеджер = s };
            var tovarSkl = new ТоварНаСкладе() { Товар = t, Количество = 10 };
            var tovarSkl2 = new ТоварНаСкладе() { Товар = t2, Количество = 5 };
            var tovarSkl3 = new ТоварНаСкладе() { Товар = t2, Количество = 4 };
            skl.ТоварНаСкладе.Add(tovarSkl);
            skl.ТоварНаСкладе.Add(tovarSkl2);
            skl2.ТоварНаСкладе.Add(tovarSkl3);
            try
            {
                var p = new DataObject[] { t, t2, s, s2, skl, skl2 };
                var ds = (SQLDataService)DataServiceProvider.DataService;
                ds.UpdateObjects(ref p);
                Console.WriteLine("ОК\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Ошибка: {0}\n", e.Message));
            }
        }

        /// <summary>
        /// Чтение данных при помощи LINQ-запросов (с использованием LINQ Provider-а Flexberry ORM).
        /// </summary>
        /// <remarks>
        /// Показан пример записи LINQ-запросов с использованием двух синтаксических вариантов:
        ///   - Явные вызовы методов расширения LINQ
        ///   - Использование встроенного в C# языка запросов
        /// </remarks>
        static void ReadObjectsLinq()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var goods = ds.Query<Товар>(Товар.Views.ТоварL.Name);
            foreach (var g in goods)
            {
                Console.WriteLine($"Название: {g.Название}\n");
            }
            var goodsC = goods.First(t => t.КодТовара == 33);
            var goodsC2 = (from g in goods where g.КодТовара == 33 select g).FirstOrDefault();

            Console.WriteLine($"Название 1: {goodsC.Название}; Название2: {goodsC2.Название}");
        }

        /// <summary>
        /// Чтение данных при помощи структуры для загрузки данных и функций ограничения.
        /// </summary>
        static void ReadObjectsLimitFunction()
        {
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Товар), Товар.Views.ТоварL);
            var ld = SQLWhereLanguageDef.LanguageDef;

            var lf = ld.GetFunction(
                ld.funcEQ,
                new VariableDef(ld.NumericType, Information.ExtractPropertyPath<Товар>(t => t.КодТовара)),
                33);

            lcs.LimitFunction = lf;
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var good = ds.LoadObjects(lcs).Cast<Товар>().FirstOrDefault();

            Console.WriteLine($"Название 1: {good?.Название}");

        }

        /// <summary>
        /// Пример получения функции ограничения из LINQ-запроса для Flexberry ORM.
        /// </summary>
        static void GetLimitFunctionFromLcs()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var goodsC = ds.Query<Товар>(Товар.Views.ТоварL.Name).Where(t => t.КодТовара == 33);
            var goodLimit = LinqToLcs.GetLcs(goodsC.Expression, Товар.Views.ТоварL).LimitFunction;

            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Товар), Товар.Views.ТоварL);
            lcs.LimitFunction = goodLimit;
            var good = ds.LoadObjects(lcs).Cast<Товар>().FirstOrDefault();

            Console.WriteLine($"Название: {good?.Название}");
        }

        /// <summary>
        /// Пример получения строкового представления объекта данных при загрузке из базы данных.
        /// </summary>
        /// <remarks>
        /// В этом случае экземпляры соответствующих объектов данных не создаются.
        /// </remarks>
        static void ReadStringedView()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(typeof(Товар), Товар.Views.ТоварL);
            var data = ds.LoadStringedObjectView(';', lcs);
            foreach (var d in data)
            {
                Console.WriteLine($"{d.Key} - {d.Data}");
            }
        }

        /// <summary>
        /// Пример наложения ограничения (фильтрации) на детейловые объекты.
        /// </summary>
        static void ReadWithDetail()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var sklad = ds.Query<Склад>(Склад.Views.СкладE);
            var tovarInSklad = from s in sklad where s.ТоварНаСкладе.Cast<ТоварНаСкладе>().Any(t => t.Количество > 5) select s;
            Console.WriteLine("Все склады:");
            foreach (var item in sklad)
            {
                Console.WriteLine($"Номер: {item.Номер}, Адрес: {item.Адрес}");
            }
            Console.WriteLine("Склады, у которых есть хотя бы один товар, количество которого > 5:");
            foreach (var item in tovarInSklad)
            {
                Console.WriteLine($"Номер: {item.Номер}, Адрес: {item.Адрес}");
            }
        }

        /// <summary>
        /// Пример использования псевдодетейлов в запросах.
        /// </summary>
        /// <remarks>
        /// Псевдодетейлы используются, когда надо наложить ограничения (фильтр) на основной объект относительно мастерового.
        /// Поскольку навигационные свойства от мастеров к основным объектам данных отсутствуют, необходимо использовать вспомогательный класс
        /// для создания "виртуальной" связи от мастера к основному объекту.
        /// </remarks> 
        static void ReadWithPseudoDetail()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var pd = new PseudoDetail<Сотрудник, Склад>(Склад.Views.СкладE, Information.ExtractPropertyPath<Склад>(s => s.Менеджер));
            var sotrs = ds.Query<Сотрудник>(Сотрудник.Views.СотрудникL);
            var sotrsInSklad = from s in sotrs where pd.Any() select s;
            Console.WriteLine("Все:");
            foreach (var item in sotrs)
            {
                Console.WriteLine($"ФИО: {item.Фамилия} {item.Имя} {item.Отчество}");
            }
            Console.WriteLine("На складе:");
            foreach (var item in sotrsInSklad)
            {
                Console.WriteLine($"ФИО: {item.Фамилия} {item.Имя} {item.Отчество}");
            }
        }

        /// <summary>
        /// Пример использования SQL-запроса, сформированного вручную, при работе с Flexberry ORM.
        /// </summary>
        static void ReadWithSQL()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var connection = (SqlConnection)ds.GetConnection();

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var sql = @"SELECT * FROM [Товар] WHERE [Товар].[КодТовара] = @Code";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("Code", 33);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var названиеТовара = reader.GetString(reader.GetOrdinal("Название"));
                            Console.WriteLine($"Название: {названиеТовара}\n");

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Пример явного включения операций работы с данными в заданные "извне" соединение и транзакцию.
        /// </summary>
        /// <remarks>
        /// Данный подход позволяет в ручном режиме контролировать те операции, которые попадают в соответствующую транзакцию,
        /// а также явно управлять транзакциями.
        /// </remarks>
        static void UsingExternalConnectionAndTransaction()
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;

            var connection = new SqlConnection(ds.CustomizationString);

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    var t = new Товар();
                    t.SetExistObjectPrimaryKey("27486786-648C-419B-B0BF-F8BA739ABF58");
                    ds.LoadObjectByExtConn(Товар.Views.ТоварL, t, true, false, new DataObjectCache(), connection, transaction);

                    t.Цена = 999;

                    var t2 = new Товар() { Название = "Стул", ЕдиницаИзмерения = "шт", Описание = "Опять мебель", Цена = 1345, КодТовара = 224 };
                    var p = new DataObject[] { t, t2 };

                    ds.UpdateObjectsByExtConn(ref p, new DataObjectCache(), true, connection, transaction);

                    transaction.Commit();
                    Console.WriteLine("ОК");
                }
            }
        }

        /// <summary>
        /// Пример чтения данных из нескольких баз данных (для баз данных, которые управляются СУБД одного типа).
        /// </summary>
        /// <remarks>
        /// В примере представлен подход подмены строки соединения с базой данных для объектов данных разных типов, т.е. разные типы объектов данных хранятся в разных базах данных.
        /// Существует еще один подход подмены базы данных для объектов разных типов - можно подменять не строку соединения, а полное имя таблицы в запросах - в этом случае
        /// используется делегат <c>ChangeClassStorageName</c> из класса <c>Information</c> (тоже статическое свойство).
        /// </remarks>
        static void ReadFromSeveralBases()
        {
            SQLDataService.ChangeCustomizationString += ChangeCustomizationString;
            var ds = (SQLDataService)DataServiceProvider.DataService;
            ds.DoNotChangeCustomizationString = true;

            var goods = ds.Query<Товар>(Товар.Views.ТоварL.Name);
            var sklads = ds.Query<Склад>(Склад.Views.СкладL.Name);
            Console.WriteLine("Товары:");
            foreach (var g in goods)
            {
                Console.WriteLine($"Название: {g.Название}\n");
            }

            Console.WriteLine("Склады:");
            foreach (var s in sklads)
            {
                Console.WriteLine($"Номер: {s.Номер}, Адрес: {s.Адрес}\n");
            }

            SQLDataService.ChangeCustomizationString = null;
        }

        private static string ChangeCustomizationString(Type[] types)
        {
            var originalConnectionString = ConfigurationManager.AppSettings["CustomizationStrings"];
            var extraConnectionString = ConfigurationManager.AppSettings["ExtraDbConnectionString"];

            return types.Any(x => x.FullName.Contains("Товар"))
                ? extraConnectionString
                : originalConnectionString;
        }
    }
}
