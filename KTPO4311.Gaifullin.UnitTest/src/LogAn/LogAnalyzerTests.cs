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
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.GDR");
            Assert.True(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithgoodextension.gdr");
            Assert.True(result);
        }
        [TestCase("filewithgoodextension.GDR")]
        [TestCase("filewithgoodextension.gdr")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string fileName)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(fileName);
            Assert.True(result);
        }
        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("Имя файла должно быть задано", ex.Message);
        }
        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.gdr", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFilenameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            analyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, analyzer.WasLastFileNameIsValid);
        }


    }
}
