using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CodeGenerator
{
    using System.IO;
    using System.IO.Compression;
    using AcademicPerformance.Objects;

    public static class CodeGenerator
    {
        public static string GetCodeForRecordBook(Студент студент)
        {
            var кодСпециальности = студент.КодСпециальности.ToString();
            if (студент.Фамилия == null || студент.Имя == null || студент.Отчество == null)
            {
                throw new ArgumentNullException(nameof(студент), "У студента не указано полное ФИО");
            }

            var знак1 = студент.Фамилия.Substring(0, 1);
            var знак2 = студент.Имя.Substring(0, 1);
            var знак3 = студент.Отчество.Substring(0, 1);
            var суффикс = $"{студент.ДатаРождения.Month}{студент.ДатаРождения.Day}";
            return $"{кодСпециальности}-{знак1}{знак2}{знак3}{суффикс}";
        }
    }
}
