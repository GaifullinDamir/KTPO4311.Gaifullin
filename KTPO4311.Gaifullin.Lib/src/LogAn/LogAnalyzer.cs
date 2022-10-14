namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    /// <summary>
    /// Анализатор лог. файлов
    /// </summary>
    public class LogAnalyzer
    {
        /// <summary>
        /// Проверка правильности имени файла
        /// </summary>
        public bool IsValidLogFileName(string fileName)
        {
            return ExtensionManagerFactory.Create().IsValid(fileName);
        }
    }
}
