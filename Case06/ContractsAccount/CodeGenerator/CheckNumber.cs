using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CheckNumber
{
    using System.IO;
    using System.IO.Compression;
    using AcademicPerformance.Objects;
    public static class CheckNumber
    {

        public static bool GetCodeForRecordBook(Договор договор)
        {           
            var эталон = "000AAA000"; // шаблон, с которым будет сверяться введенный номер договора. "0" - цифра, "А" - буква
            string symb = "0123456789";
            char[] числа = symb.ToCharArray();
            string symb2 = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮQWERTYUIOPASDFGHJKLZXCVBNM-()/.";//допустимые символы (нет проверки на несколько "-()/." подряд, несложно доделать)
            char[] буквы = symb2.ToCharArray();
            var номерДоговора = договор.номерДоговора.ToUpper();
            var count = 0;
            int длинаНомераДоговора = номерДоговора.Length;
            int длинаЭталона = эталон.Length;
            int разница = (длинаЭталона - длинаНомераДоговора);
    var корректность = true; // во избежание выполнения лишнего кода return стоит в 4 местах ниже
            if(договор.Информация == "")
            {
                return корректность = false;
            }
            else { 

            if (разница < 0) // если введенный номер больше эталона (в самом элементе формы стоит ограничение на 12 символов)
            {
               // номерДоговора = "Некорректное значение!";
                return корректность = false;
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
                          //  номерДоговора = "Некорректное значение! первой должна быть буква";
                            корректность = false; }
                            break;                    
                    }
                }


                if (длинаНомераДоговора < count)
                {
                  //  номерДоговора = "Некорректное значение! длина меньше";
                    return корректность = false;
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
                                   // номерДоговора = "Некорректное значение! Уберите пробел";
                                    корректность = false;
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
                     //   номерДоговора = "Некорректное значение! не совпадает с эталоном";
                        корректность = false;
                        break;
                    }
                }
            }
            return корректность;
        }
        }
    }
}
