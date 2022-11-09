namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    public class Presenter
    {
        private ILogAnalyzer logAnalyzer = null;
        private IView view = null;
        public Presenter(ILogAnalyzer logAnalyzer, IView view)
        {
            this.logAnalyzer = logAnalyzer;
            this.view = view;
            logAnalyzer.Analyzed += OnLogAnalyzed;
        }

        private void OnLogAnalyzed()
        {
            view.Render("Обработка завершена");
        }
    }
}
