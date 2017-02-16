namespace AcademicPerformance.Tests
{
    using System;
    using Xunit;

    using AcademicPerformance.Objects;
    using CodeGenerator;

    public class CodeGeneratorTests
    {
        [Fact]
        public void TestGetCodeForRecordBook_CorrectStudent()
        {
            ///Arrange.
            var студент = new Студент()
            {
                Фамилия = "Иванов",
                Имя = "Иван",
                Отчество = "Иванович",
                ДатаРождения = new DateTime(1994, 2, 14),
                НомерГруппы = "ПГШ-11",
                КодСпециальности = КодСпециальности.ПМИ
            };

            var expectedКодЗачетки = "ПМИ-ИИИ214";

            ///Act.
            var кодЗачетки = CodeGenerator.GetCodeForRecordBook(студент);

            ///Assert.
            Assert.Equal(expectedКодЗачетки, кодЗачетки);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectStudentSurname()
        {
            ///Arrange.
            var студент = new Студент()
            {
                Фамилия = null,
                Имя = "Иван",
                Отчество = "Иванович",
                ДатаРождения = new DateTime(1994, 2, 14),
                НомерГруппы = "ПГШ-11",
                КодСпециальности = КодСпециальности.ПМИ
            };

            ///Act.
            var ex = Assert.Throws<ArgumentNullException>(() => CodeGenerator.GetCodeForRecordBook(студент));

            ///Assert.
            Assert.Contains("У студента не указано полное ФИО", ex.Message);
        }
    }
}
