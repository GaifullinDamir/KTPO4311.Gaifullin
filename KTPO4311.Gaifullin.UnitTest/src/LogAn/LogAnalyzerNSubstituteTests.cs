using KTPO4311.Gaifullin.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4311.Gaifullin.UnitTest.src.LogAn
{
    class LogAnalyzerNSubstituteTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("short.gdr").Returns(true);

            //Кофнигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.gdr");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
        {
            IExtensionManager fakeManager = Substitute.For<IExtensionManager>();
            fakeManager.IsValid("short.gdr").Returns(true);
            
            //Конфигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("long.gdr");

            //Проверка ожидаемого результата
            Assert.IsFalse(result);
        }
    }
}
