using KTPO4311.Gaifullin.Lib.src.LogAn;

namespace KTPO4311.Gaifullin.Service.src.Views
{
    public class ConsoleView : IView
    {
        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}

