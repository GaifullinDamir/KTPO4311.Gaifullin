namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    /// <summary>Анализатор лог. файлов</summary>
    public class LogAnalyzer
    {
        /// <summary>Проверка правильности имени файла</summary>
        public bool IsValidLogFileName(string fileName)
        {
            try
            {
                return ExtensionManagerFactory.Create().IsValid(fileName);
            }
            catch
            {
                return false;
            }
        }
        ///<summary>Анализировать лог. файл</summary>
        ///<param name= "fileName"></param>
        public void Analyze(string fileName)
        {
            if(fileName.Length < 8)
            {
                try
                {
                    //Передать внешней службе сообщение об ошибке
                    IWebService service = WebServiceFactory.Create();
                    service.LogError("Слишком короткое имя файла:" + fileName);
                }
                catch (Exception excep)
                {
                    //Отправить сообщение по электронной почте
                    IEmailService emailService = EmailServiceFactory.Create();
                    emailService.SendEmail("someone@somewhere.com", "Невозможно вызвать веб-сервис", excep.Message);
                }
                
            }
        }
    }
}
