using KTPO4311.Gaifullin.Lib.src.LogAn;
using NUnit.Framework;
namespace KTPO4311.Gaifullin.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }
    }
}
