using KTPO4311.Gaifullin.Lib.src.LogAn;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.True(result);
        }
    }
}
