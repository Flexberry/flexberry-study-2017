using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CheckNumber
{
    using System.IO;
    using System.IO.Compression;
    using System.Configuration;
    public static class CheckNumber
    {

        public static string GetCodeForRecordBook(string договор)
        {
            var эталон = ConfigurationManager.AppSettings["template"];//шаблон
            string symb = ConfigurationManager.AppSettings["symbols"];//цифры
            char[] числа = symb.ToCharArray();
            string symb2 = ConfigurationManager.AppSettings["symbols2"];//буквы и символы
            char[] буквы = symb2.ToCharArray();
            var номерДоговора = договор.ToUpper();
            var count = 0;
            int длинаНомераДоговора = номерДоговора.Length;
            int длинаЭталона = эталон.Length;
            int разница = (длинаЭталона - длинаНомераДоговора);
    var корректность = "true"; 
            
              

            if (разница < 0) // если введенный номер больше эталона (в самом элементе формы стоит ограничение на 12 символов)
            {
                    корректность = "Длина введенного номера больше длины эталона";
            }
            else
            {
                var массив = Encoding.Default.GetChars(Encoding.Default.GetBytes(эталон));
                for (int i = 0; i < массив.Length; i++)
                {
                    if (массив[i] == '0')
                    {
                        count = длинаЭталона - i; // если формат 00А0, то если вводим 1А4 и 01А4, это одно и то же. Поэтому нужно...
                    }
                    else if (массив[i] == 'A')
                    {
                        if ((i == 0) && (разница != 0))// .... вот это условие
                        {
                            корректность = "Первым должен быть символ другого типа!"; }
                            break;                    
                    }
                }


                if (длинаНомераДоговора < count)
                {
                        корректность = "Длина введенного номера меньше длины эталона!";
                }


                 var массив1 = Encoding.Default.GetChars(Encoding.Default.GetBytes(номерДоговора));
                for (int i = 0; i < массив1.Length; i++) // переводим введенный номер в код для сравнения с эталоном (распознаем цифры и допустимые символы)
                {
                    foreach (char a in числа)
                    {
                        foreach (char b in буквы)
                        {
                            if (массив1[i] == a)
                            {
                                массив1[i] = '0';
                            continue;
                            }
                            else
                            {
                                if (массив1[i] == b)
                                    массив1[i] = 'A';
                                else if (массив1[i] == ' ')
                                {
                                    корректность = "Номер договора не должен содержать пробелы";
                                    break;
                                }
                            }
                        }
                    }
                }

            
            for (int i = 0; i < массив1.Length; i++)
                {
                     if (массив1[i] != массив[i + разница])
                    {
                        корректность = "Некорректное значение. Не совпадает с эталоном!";
                        break;
                    }
                }
            }
            return корректность;        
        }
    }
}
