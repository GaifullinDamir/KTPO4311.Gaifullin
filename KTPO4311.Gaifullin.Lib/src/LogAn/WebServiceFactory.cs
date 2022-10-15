namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика веб-сервиса
    /// </summary>
    public static class WebServiceFactory
    {
        private static IWebService customService = null;

        ///<summary>Создание объектов </summary>
        public static IWebService Create()
        {
            if (customService != null)
            {
                return customService;
            }
            return new WebService();
        }
        ///<summary>Метод позволит тестам контролировать, 
        ///что возвращает фабрика</summary>
        ///<param name="srvc"></param>
        public static void SetWebService(IWebService srvc)
        {
            customService = srvc;
        }
    }
}
