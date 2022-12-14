using KTPO4311.Gaifullin.Lib.src.LogAn;

namespace KTPO4311.Gaifullin.Lib.src.SampleCommands
{
    public class ExceptionCommandDecorator : ISampleCommand
    {
        private readonly ISampleCommand _sampleCommand;
        private readonly IView _view;

        public ExceptionCommandDecorator(ISampleCommand sampleCommand, IView view)
        {
            _sampleCommand = sampleCommand;
            _view = view;
        }
        public void Execute()
        {
            try
            {
                _sampleCommand.Execute();
            }
            finally
            {
                _view.Render("Перехват исключений: " + this.GetType().ToString());
            }
        }
    }
}
