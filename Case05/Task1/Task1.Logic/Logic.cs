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
    // 6 - год, месяц, день по 2 на каждый
    // 7 - первых букв названия
    // 5 - последних цифр лицевого счета
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
            var day = formatLength.format($"{user.DateReg.Day}",2, '0').Substring(0, 2);

            var name = formatLength.format(user.Name, 7,'_');

            var ls = $"{user.Account}";
            if (ls.Length > 5)
            {
                 ls = ls.Remove(0, ls.Length - 5);
            }
            else
            {
                 ls = formatLength.format(ls, 5, '0');
            }

            return year + month + day + name + ls;
        }
    }

    //алгоритм 2
    //код состоит из 18 символов, в таком пордяке:
    // 7 - код лицевого счета из латинских букв и цифр ( номер лс преобразован в 36ю сис.счисления) 
    // 5 - первых букв из названия
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
            var name = formatLength.format(user.Name, 5,'_');
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