namespace AcademicPerformance.Tests
{
    using System;
    using NewPlatform.RecordBookBL;
    using Xunit;

    public class CodeGeneratorTests
    {
        [Fact]
        public void TestGetCodeForRecordBook_CorrectStudent()
        {
            // Arrange.
            var студент = new Студент()
            {
                Фамилия = "Иванов",
                Имя = "Иван",
                Отчество = "Иванович",
                ДатаРождения = new DateTime(1994, 2, 14),
                Группа = new Группа() { Специальность = new Специальность() { КодСпециальности = "ПМИ" } }
            };

            var expectedКодЗачетки = "ПМИ-ИИИ214";

            // Act.
            var кодЗачетки = CodeGenerator.GetCodeForRecordBook(студент);

            // Assert.
            Assert.Equal(expectedКодЗачетки, кодЗачетки);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectStudentSurname()
        {
            // Arrange.
            var студент = new Студент()
            {
                Фамилия = null,
                Имя = "Иван",
                Отчество = "Иванович",
                ДатаРождения = new DateTime(1994, 2, 14),
                Группа = new Группа() { Специальность = new Специальность() { КодСпециальности = "ПМИ" } }
            };

            // Act.
            var ex = Assert.Throws<ArgumentNullException>(() => CodeGenerator.GetCodeForRecordBook(студент));

            // Assert.
            Assert.Contains("У студента не указано полное ФИО", ex.Message);
        }
    }
}
