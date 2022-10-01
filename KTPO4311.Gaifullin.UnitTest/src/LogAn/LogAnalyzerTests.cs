using KTPO4311.Gaifullin.Lib.src.LogAn;
using NUnit.Framework;
namespace KTPO4311.Gaifullin.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_ReturnsTrue()
        {
            //Подготовка теста
            LogAnalyzer analyzer = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = analyzer.IsValidLogFileName("f.GDR");

            //Проверка ожидаемого результата
            Assert.True(result);
        }
    }
}
