namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    /// <summary>
    /// Анализатор лог. файлов
    /// </summary>
    public class LogAnalyzer
    {
        IExtensionManager mrg;
        public LogAnalyzer()
        {
            mrg = new FileExtensionManager();
        }
        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
            return mrg.IsValid(fileName);
        }
    }
}
