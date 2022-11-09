namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    public interface ILogAnalyzer
    {
        event LogAnalyzerAction Analyzed;
        void Analyze(string fileName);
        bool IsValidLogFileName(string fileName);
    }
}
