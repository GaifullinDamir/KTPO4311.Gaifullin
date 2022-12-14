using KTPO4311.Gaifullin.Lib.src.LogAn;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace KTPO4311.Gaifullin.Lib.src.SampleCommands
{
    public class SampleCommandDecorator : ISampleCommand
    {
        private readonly ISampleCommand _sampleCommand;
        private readonly IView _view;
        public SampleCommandDecorator(ISampleCommand sampleCommand, IView view)
        {
            _sampleCommand = sampleCommand;
            _view = view;
        }
        public void Execute()
        {
            _view.Render("Начало: " + this.GetType().ToString());
            try
            {
                _sampleCommand.Execute();
            }
            catch (Exception)
            {
                _view.Render("Конец: " + this.GetType().ToString());
            } 
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISampleCommand>().ImplementedBy<SampleCommandDecorator>().LifeStyle.Singleton,
                Component.For<ISampleCommand>().ImplementedBy<FirstCommand>().LifeStyle.Singleton
        };
    }
