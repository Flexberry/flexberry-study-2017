﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeploCorp.TeploUchet
{
    using System;
    using System.Xml;


    // *** Start programmer edit section *** (Using statements)
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using System.Linq;
    using Task1.Objects;
    using Logic;

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Генерация кода.
    /// </summary>
    // *** Start programmer edit section *** (ГенерацияКода CustomAttributes)

    // *** End programmer edit section *** (ГенерацияКода CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class ГенерацияКода : ICSSoft.STORMNET.Business.BusinessServer
    {
        
        // *** Start programmer edit section *** (ГенерацияКода CustomMembers)

        // *** End programmer edit section *** (ГенерацияКода CustomMembers)

        
        // *** Start programmer edit section *** (OnUpdateОбъект CustomAttributes)
        /// <summary>
        /// генерция кода для объекта
        /// </summary>
        /// <param name="object4Code"></param>

        public string generateCode(TeploCorp.TeploUchet.Объект object4Code)
        {
            var consumer = new Consumer()
            {
                Name = object4Code.Наименование,
                Account = object4Code.ЛицСчет,
                DateReg = object4Code.ДатаРегистрации
            };
            return Logic1.GenerateCode(consumer);
        }

        /// <summary>
        /// вычисление площади объекта
        /// </summary>
        /// <param name="object4Calc"></param>
        public void calcArea (TeploCorp.TeploUchet.Объект object4Calc)
        {
            //var ds = (SQLDataService)DataServiceProvider.DataService;
            IDataService ids = DataServiceProvider.DataService;
            var objectKey = object4Calc.Здание.__PrimaryKey;
            int OldПлощадь = 0;
            var noToSummObject = ids.Query<Объект>(Объект.Views.ОбъектE)
                                    .Where(y => y.__PrimaryKey == object4Calc.__PrimaryKey)
                                    .Where(y => y.Актуален == true);
            foreach (var j in noToSummObject)
            {
                OldПлощадь = j.Площадь;
            };
            if (object4Calc.Площадь != OldПлощадь)
            {
                //прибавляем новую площадь и вычитаем старую компенсируя потом прибавкой её из старых значений
                object4Calc.Здание.Площади = object4Calc.Площадь - OldПлощадь;
                //находим старые площади и прибавляем
                var toSummObjects = ids.Query<Объект>(Объект.Views.ОбъектE)
                                        .Where(y => y.Здание.__PrimaryKey == objectKey)
                                        .Where(y => y.Актуален == true);
                foreach (var j in toSummObjects)
                {
                    object4Calc.Здание.Площади += j.Площадь;
                };
                ids.UpdateObject(object4Calc.Здание);
            }
        }
        /// <summary>
        /// поиск дубля по наименованию
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Boolean chesk4double(string Value)
        {
            IDataService ids = DataServiceProvider.DataService;
            var ToCheck = ids.Query<Объект>(Объект.Views.ОбъектE)
                                .Where(x => x.Наименование == Value)
                                .Where(y => y.Актуален == true);
            var xxx = ToCheck.Count();
            if (ToCheck.Count() != 0 )
            {
                return true;
            }
            return false;
        }
        // *** End programmer edit section *** (OnUpdateОбъект CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateОбъект(TeploCorp.TeploUchet.Объект UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateОбъект)
            
            if (UpdatedObject.GetStatus() == ObjectStatus.Created || UpdatedObject.GetStatus() == ObjectStatus.Altered)
            {
                //считаем код объекта
                UpdatedObject.КодОбъекта = generateCode(UpdatedObject);
                //считаем площадь объектов в здании
                calcArea(UpdatedObject);
            }
            
            //ставим флаг удален 
            if (UpdatedObject.GetStatus() == ObjectStatus.Deleted)
            {
                DataService.LoadObject(UpdatedObject);
                UpdatedObject.SetStatus(ObjectStatus.Altered);
                UpdatedObject.Актуален = false;

                var ds = (SQLDataService)DataServiceProvider.DataService;
                var delObjects = ds.Query<Объект>(Объект.Views.ОбъектE).Where(k => k.Здание.__PrimaryKey == UpdatedObject.__PrimaryKey);
                foreach (var k in delObjects)
                {
                    k.SetStatus(ObjectStatus.Deleted);
                }
                return delObjects.ToArray();
            }

            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateОбъект)
        }
    }
}
