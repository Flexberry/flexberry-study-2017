using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    using System.IO;
    using Task1.Objects;

    //алгоритм 1
    //код состоит из 18 символов, в таком пордяке:
    // 6 - год, месяц, день по 2 последних символа 
    // 5 - название пересчитанное в хэш и переведённое в 62 алф.
    // 5 - лицевой счет переведённый в 62 афл.
    public class Logic1
    {
        public static string GenerateCode(Consumer user)
        {
            if (user.Account == 0 || user.Account == 0 || user.Name == null)
            {
                throw new ArgumentNullException(nameof(user), "Не заполнены все поля формы");
            }
            var year = Logicformat.Length($"{user.DateReg.Year}",4,'0').Substring(0,4);            
            var month = Logicformat.Length($"{user.DateReg.Month}",2,'0').Substring(0, 2);
            var day = Logicformat.Length( $"{user.DateReg.Day}",2, '0' ).Substring(0, 2); //8
            var name = Logicformat.Length(Logicformat.HashName(user.Name), 5,'_'); //13
            var ls = Logicformat.Length(Logicformat.In62alf(user.Account) , 5, '0'); //18
            return year + month + day + name + ls;
        }
    }

    //алгоритм 2
    //код состоит из 18 символов, в таком пордяке:
    // 3 - первые буквы названия
    // 2 - цифры лиц счета
    // 6 - год, месяц, день
    // 1 - год в 62 алф.
    // 3 - хэш названия
    // 2 - хэш лс
    public class Logic2
    {
        public static string GenerateCode(Consumer user)
        {
            if (user.Account == 0 || user.Account == 0 || user.Name == null)
            {
                throw new ArgumentNullException(nameof(user), "Не заполнены все поля формы");
            }
            var year = Logicformat.Length($"{user.DateReg.Year}", 4, '0').Substring(2, 2); 
            var month = Logicformat.Length($"{user.DateReg.Month}", 2, '0').Substring(0, 2);
            var day = Logicformat.Length($"{user.DateReg.Day}", 2, '0').Substring(0, 2);
            var yearIn62 = Logicformat.In62alf( Convert.ToUInt64($"{user.DateReg.Year}")).Substring(0, 2);  //8
            var name = Logicformat.Length($"{user.Name}", 3,'_');  // 11
            var nameHash = Logicformat.Length(Logicformat.HashName($"{user.Name}"), 3, '_');  //14
            var lsHash = Logicformat.Length(Logicformat.HashName($"{user.Account}"), 2, '0').Substring(0, 2); //16
            var ls = Logicformat.Length($"{user.Account}", 2, '0');
            return name + ls + year + month + day + yearIn62 + nameHash + lsHash;
        }
    }

    public class Logicformat
    {
        //делаем строку требуемой длинны length
        //обрезая или дополняя нужным символом
        public static string Length(string var, int length, char Simbol)
        {
            if (var.Length < length)
            {
                do
                {
                    var = Simbol + var;
                }
                while (var.Length < length);
                return var;
            }
            else
            {
                return var.Substring(0, length);
            }
        }

        //хэш из наименования потребителя
        public static string HashName(string val)
        {
            ulong tmp = 191; // 10 + 26*2 + 33*2 = 190
            ulong hash = 0, tmp_pow = 1;
            for (int i = 0; i < val.Length; ++i)
            {
                try
                {
                    hash += ((ulong)val[i] - (int)'0' + 1) * tmp_pow;
                    tmp_pow *= tmp;
                }
                catch (OverflowException)
                {
                    throw new ArgumentNullException($"{hash}", "Переполнение типа в hash");
                }
            }
            return In62alf(hash);
        }
        //перевод в 62 сим алф
        public static string In62alf(ulong val)
        {
            string tmp = "";
            do
            {
                //0..9 - 10
                //А..Z - 26
                //а..z 
                ulong i = val % 62;

                if (i > 35)
                {
                    i += (int)'a' - 36;
                }
                else
                {
                    if (i > 9)
                    {
                        i += (int)'A' - 10;
                    }
                    else
                    {
                        i += (int)'0';
                    }
                }
                tmp = (char)i + tmp;
                val /= 62;
            } while (val > 0);

            return tmp;
        }

        //строку по символьно преобразуем число
        //Dec значение символа по юникоду соединяем строку
        public static ulong StringToInt(string val)
        {
            ulong tmp = 0;
            for (int i = 0; i < val.Length; i++)
            {
                int char_i = val[i]; // Dec значение символа по юникоду
                int step = -1;
                do
                {
                    step++;
                    char_i /= 10;
                } while (char_i > 0);
                try
                {
                    tmp = tmp * (ulong)((int)Math.Pow(10, step + 1)) + val[i];
                }
                catch (OverflowException)
                {
                    throw new ArgumentNullException($"{tmp}", "Переполнение типа в StringToInt");
                }
            }
            return tmp;
        }
    }
}