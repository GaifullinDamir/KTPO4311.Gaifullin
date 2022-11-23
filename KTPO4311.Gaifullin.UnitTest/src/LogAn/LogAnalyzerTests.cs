using KTPO4311.Gaifullin.Lib.src.LogAn;
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

        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            //Подготовка теста
            FakeWebService mockWebService = new FakeWebService();
            WebServiceFactory.SetWebService(mockWebService);
            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.gdr";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого результата
            StringAssert.Contains("Слишком короткое имя файла:abc.gdr",
                mockWebService.LastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            //Подготовка теста
            FakeWebService stubWebService = new FakeWebService();
            WebServiceFactory.SetWebService(stubWebService);
            stubWebService.WillThrowWeb = new Exception("Это подделка");
            
            FakeEmailService mockEmail = new FakeEmailService();
            EmailServiceFactory.SetEmailService(mockEmail);

            LogAnalyzer log = new LogAnalyzer();
            string tooShortFileName = "abc.gdr";

            //Воздействие на тестируемый объект
            log.Analyze(tooShortFileName);

            //Проверка ожидаемого реультата
            //...Здесь тест будет ложным, если неверно хотя бы одно утверждение
            //...Поэтому здесь допустимо несколько утверждений
            StringAssert.Contains("someone@somewhere.com", mockEmail.to);
            StringAssert.Contains("Это подделка", mockEmail.body);
            StringAssert.Contains("Невозможно вызвать веб-сервис", mockEmail.subject);

        }

        [Test]
        public void Analyze_WhenAnalyzed_FiredEvent()
        {
            //Подготовка теста
            bool analyzedFired = false;

            LogAnalyzer logAnalyzer = new LogAnalyzer();

            //..используем анонимный метод в качестве обработчика события
            logAnalyzer.Analyzed += delegate ()
            {
                analyzedFired = true;
            };

            //Воздействие на тестируемый объект
            logAnalyzer.Analyze("validfilename.gdr");

            //Проверка ожидаемого результата
            Assert.IsTrue(analyzedFired);
        }

        [TearDown] 
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
            WebServiceFactory.SetWebService(null);
            EmailServiceFactory.SetEmailService(null);
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
    ///<summary>Поддельная веб-служба</summary>
    internal class FakeWebService : IWebService
    {
        /// <summary>Это поле запоминает состояние после вызова метода LogError
        /// при тестировании взаимодействия утверждения высказываются относительно</summary>
        public string LastError;
        public Exception WillThrowWeb = null;

        public void LogError(string message)
        {
            if(WillThrowWeb != null)
            {
                throw WillThrowWeb;
            }
            LastError = message;
        }
    }
    /// <summary>
    /// Подддельная EMail - служба
    /// </summary>
    internal class FakeEmailService : IEmailService
    {
        ///<summary> Это поле запоминает состояние после вызова метода SendMail
        ///при тестировании взаимодействия утверждения высказывается относительно</summary>
        public string to, subject, body;

        public void SendEmail(string to, string subject, string body)
        {
            this.to = to;
            this.subject = subject;
            this.body = body;
        }
    }
}
