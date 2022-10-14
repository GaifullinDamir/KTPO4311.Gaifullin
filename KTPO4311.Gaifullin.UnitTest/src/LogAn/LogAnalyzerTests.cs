﻿using KTPO4311.Gaifullin.Lib.src.LogAn;
using NUnit.Framework;
namespace KTPO4311.Gaifullin.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            //Кофнигурируем фабрику для создания поддельных объектов
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();
            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.gdr");

            //Проверка ожидаемого результата
            Assert.True(result);
        }

        [Test]
        public void IsValidFileName_NameNotSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("long.gdr");

            //Проверка ожидаемого результата
            Assert.False(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnFalse()
        {
            //Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            fakeManager.WillThrow = new Exception();
            ExtensionManagerFactory.SetManager(fakeManager);
            LogAnalyzer log = new LogAnalyzer();

            //Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.gdr");

            //Проверка ожидаемого результата
            Assert.False(result);
        }

        [TearDown] 
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetService(null);
        }
    }

    /// <summary>
    /// Поддельный менеджер расширений
    /// </summary>
    internal class FakeExtensionManager : IExtensionManager
    {
        ///<summary>Это поле позволяет настроить
        ///поддельный результат для метода IsValid</summary>
        public bool WillBeValid = false;

        /// <summary>
        /// Это поле позволяет настроить поддельное 
        /// исключение вызываемое в методе IsValid
        /// </summary>
        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {
            if(WillThrow != null)
            {
                return false;
            }
            return WillBeValid;
        }
    }
}
