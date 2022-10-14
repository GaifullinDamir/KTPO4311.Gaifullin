
namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    /// <summary>
    /// Фабрика веб-сервисов
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
        public static void SetService(IWebService srvc)
        {
            customService = srvc;
        }
    }
}
