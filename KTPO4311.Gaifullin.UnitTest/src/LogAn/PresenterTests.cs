using KTPO4311.Gaifullin.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4311.Gaifullin.UnitTest.src.LogAn
{
    internal class PresenterTests
    {
        [Test]
        public void ctor_WhenAnalyzed_CallseViewRender()
        {
            FakeLogAnalyzer mockLog = new FakeLogAnalyzer();
            IView view = Substitute.For<IView>();
            Presenter presenter = new Presenter(mockLog, view);

            mockLog.CallRaiseAnalyzedEvent();
            view.Received().Render("Обработка завершена");
        }

        [Test]
        public void ctor_WhenAnalyzed_CallsViewRender_NSubstitute()
        {
            ILogAnalyzer stubLogAnalyzer = Substitute.For<ILogAnalyzer>();
            IView view = Substitute.For<IView>();
            Presenter presenter = new Presenter(stubLogAnalyzer, view);
            stubLogAnalyzer.Analyzed += Raise.Event<LogAnalyzerAction>();

            view.Received().Render("Обработка завершена");
        }
    }

    ///<summary>Заглушка для имитации вызова события</summary>
    class FakeLogAnalyzer : LogAnalyzer
    {
        public void CallRaiseAnalyzedEvent()
        {
            base.RaiseAnalyzedEvent();
        }
    }
}
