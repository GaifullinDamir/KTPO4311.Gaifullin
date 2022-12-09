using Castle.Windsor;

namespace KTPO4311.Gaifullin.Lib.src.Common
{
    public static class CastleFactory
    {
        ///<summary>Контейнер</summary>>
        public static IWindsorContainer container { get; private set; }

        static CastleFactory()
        {
            //Создать объект контейнер
            container = new WindsorContainer();
        }
    }
}
