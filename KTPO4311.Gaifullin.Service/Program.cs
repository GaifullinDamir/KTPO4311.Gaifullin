using KTPO4311.Gaifullin.Lib.src.Common;
using KTPO4311.Gaifullin.Lib.src.LogAn;
using KTPO4311.Gaifullin.Lib.src.SampleCommands;
using KTPO4311.Gaifullin.Service.src.WindsorInstallers;

CastleFactory.container.Install(
    new SampleCommandInstaller(),
    new ViewInstaller()
    );


for (int i = 0; i < 3; i++)
{
    ISampleCommand someCommand = CastleFactory.container.Resolve<ISampleCommand>();
    someCommand.Execute();
}

//LogAnalyzer logAnalyzer = new LogAnalyzer();
//if(logAnalyzer.IsValidLogFileName("someName.gdr"))
//{
//    Console.WriteLine("Файл someName.gdr с правильным расширением");
//}
//else
//{
//    Console.WriteLine("Файл someName.gdr с неправильным расширением");
//}

//if(logAnalyzer.IsValidLogFileName("someName.dgr"))
//{
//    Console.WriteLine("Файл someName.dgr с правильным расширением");
//}
//else
//{
//    Console.WriteLine("Файл someName.dgr с неправильным расширением");
//}
