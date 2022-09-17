namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Имя файла должно быть задано.");
            }
            if(fileName.EndsWith(".GDR", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
