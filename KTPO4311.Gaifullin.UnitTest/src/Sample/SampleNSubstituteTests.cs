using KTPO4311.Gaifullin.Lib.src.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace KTPO4311.Gaifullin.UnitTest.src.Sample
{
    class SampleNSubstituteTests
    {
        [Test]
        public void Returns_ParticularArg_Works()
        {
            //Создать поддельный объект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true для заданного значения входного параметра
            fakeExtensionManager.IsValid("validfile.ext").Returns(true);

            //Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("validfile.ext");

            //Проверка ожидаемого результата
            Assert.IsTrue(result);
        }

        [Test]
        public void Returns_ArgAny_Works()
        {
            //Создать поддельный оюъект
            IExtensionManager fakeExtensionManager = Substitute.For<IExtensionManager>();

            //Настроить объект, чтобы метод возвращал true независимо от параметров
            fakeExtensionManager.IsValid(Arg.Any<string>()).Returns(true);

            //Воздействие на тестируемый объект
            bool result = fakeExtensionManager.IsValid("anyfile.ext");

            //Проверка ожидаемого результата
            Assert.True(result);
        }
    }
}
