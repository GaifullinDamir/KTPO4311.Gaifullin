using KTPO4311.Gaifullin.Lib.src.LogAn;

namespace KTPO4311.Gaifullin.Lib.src.SampleCommands
{
    public class SecondCommand : ISampleCommand
    {
        private readonly IView _view;
        private int iExecute = 0;

        public SecondCommand(IView view)
        {
            _view = view;
        }

        public void Execute()
        {
            iExecute++;
            _view.Render(this.GetType().ToString() + "\n iExecute = " + iExecute);
            throw new System.NotImplementedException();
        }
    }
}
