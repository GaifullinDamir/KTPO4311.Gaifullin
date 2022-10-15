namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    public static class EmailServiceFactory
    {
        private static IEmailService customEmail = null;
        ///<summary>Создание объектов</summary>
        public static IEmailService Create()
        {
            if(customEmail != null)
            {
                return customEmail;
            }
            return new EmailService();
        }
        ///<summary>Метод позволяет контролировать, 
        ///что возвращает фабрика</summary>
        public static void SetEmailService(IEmailService esrvc)
        {
            customEmail = esrvc;
        }
    }
}
