namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if(fileName.EndsWith(".GDR"))
            {
                return false;
            }
            return true;
        }
    }
}
