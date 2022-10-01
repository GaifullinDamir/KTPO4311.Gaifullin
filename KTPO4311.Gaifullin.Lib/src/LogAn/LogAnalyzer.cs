namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    /// <summary>
    /// Анализатор лог. файлов
    /// </summary>
    public class LogAnalyzer
    {
        private readonly IExtensionManager _mrg;
        public LogAnalyzer(IExtensionManager mrg)
        {
            _mrg = mrg;
        }
        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
            return _mrg.IsValid(fileName);
        }
    }
}
