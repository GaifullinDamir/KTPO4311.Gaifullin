﻿using KTPO4311.Gaifullin.Lib.src.LogAn;
namespace KTPO4311.Gaifullin.Lib.src.SampleCommands
{
    public class FirstCommand : ISampleCommand
    {
        private readonly IView _view;
        private int iExecute = 0;

        public FirstCommand(IView view)
        {
            _view = view;
        }
        public void Execute()
        {
            iExecute++;
            _view.Render(this.GetType().ToString() + "\n iExecute = " + iExecute);
        }
    }
}
