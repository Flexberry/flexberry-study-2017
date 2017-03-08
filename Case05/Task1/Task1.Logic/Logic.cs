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
    // 7 - название пересчитанное в хэш и переведённое в цифры и латинские символы
    // 5 - лицевой счет переведённый в цифры и латинские символы
    public class Logic1
    {
        public static string GenerateCode(Consumer user)
        {
            if (user.Account == 0 || user.Account == 0 || user.Name == null)
            {
                throw new ArgumentNullException(nameof(user), "Не заполнены все поля формы");
            }
            var year = formatLength.format($"{user.DateReg.Year}",4,'0').Substring(2,2);            
            var month = formatLength.format($"{user.DateReg.Month}",2,'0').Substring(0, 2);
            var day = formatLength.format( $"{user.DateReg.Day}",2, '0' ).Substring(0, 2);
            var name = formatLength.format( HashName(user.Name), 7,'_');
            var ls = formatLength.format(In62alf(user.Account) , 5, '0');
            return year + month + day + name + ls;
        }
        public static string HashName(string val)
        {
            ulong tmp = 191; // 10 + 26*2 + 33*2 = 190
            ulong hash = 0, tmp_pow = 1;
            for (int i = 0; i < val.Length; ++i)
            {
                try
                {
                    hash += ( (ulong)val[i] - (int)'0' + 1) * tmp_pow;
                    tmp_pow *= tmp;
                }
                catch (OverflowException)
                {
                    throw new ArgumentNullException( $"{hash}", "Переполнение типа в hash");
                }
            }

            return In62alf(hash);
        }
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
    }

    //алгоритм 2
    //код состоит из 18 символов, в таком пордяке:
    // 7 - код лицевого счета из латинских букв и цифр (номер лс преобразован в 36 сис.счисления) 
    // 5 - символы названия переведены в 10е числа, собраны в строку и пересчитаны в 36 сис.счисления 
    // 6 - год, месяц, день
    //позволяет длинный номер лс записать в коде

    public class Logic2
    {
        public static string GenerateCode(Consumer user)
        {
            if (user.Account == 0 || user.Account == 0 || user.Name == null)
            {
                throw new ArgumentNullException(nameof(user), "Не заполнены все поля формы");
            }
            var year = formatLength.format($"{user.DateReg.Year}", 4, '0').Substring(2, 2);
            var month = formatLength.format($"{user.DateReg.Month}", 2, '0').Substring(0, 2);
            var day = formatLength.format($"{user.DateReg.Day}", 2, '0').Substring(0, 2);
            var name = formatLength.format(IntoLat(StringToInt(user.Name)), 5,'_');
            var ls = formatLength.format($"{IntoLat(user.Account)}", 7, '0').Substring(0, 7);
            return ls + name + year + month + day;
        }

        //преобразуем номер лс в латинские символы и цифры
        public static string IntoLat(ulong val)
        {
            string tmp = "";
            do
            {
                ulong i = val % 36;
                if (i > 9)
                {
                    i += (int)'A' - 10;
                }
                else
                {
                    i += (int)'0';
                }
                tmp = (char)i + tmp;
                val /= 36;
            } while (val > 0);
            return tmp;
        }
        public static ulong StringToInt(string val)
        {
            ulong tmp = 0;
            for (int i=0; i < val.Length; i++)
            {
                tmp += (ulong)val[i] ;
            }
            return tmp;
        }
    }

    //делаем строку требуемой длинны length
    //обрезая или дополняя нужным символом
    public class formatLength
    {
        public static string format(string var, int length, char Simbol)
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
   
    }
}