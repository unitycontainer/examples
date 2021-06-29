using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Injection;
using Unity;

namespace Injecting
{
    public partial class Constructors
    {
        #region ResolvedParameter()

        [TestMethod(As_Annotated), TestProperty(PARAMETER, nameof(ResolvedParameter))]
        public void With_ResolvedParameter()
        {
            // Inject parameter with value resolved from container with contract
            // determined by ParameterInfo
            Container.RegisterType<Examples.Implicit.TestType<string>>(
                new InjectionConstructor(new ResolvedParameter()));

            // Resolve with non attributed dependency
            var instance = Container.Resolve<Examples.Implicit.TestType<string>>();

            // By default resolved unnamed contract
            Assert.AreEqual(RegisteredString, instance.DependencyCtor);
        }


        [TestMethod(As_Annotated_Named), TestProperty(PARAMETER, nameof(ResolvedParameter))]
        public void Named_With_ResolvedParameter()
        {
            // Inject parameter with value resolved from container with contract
            // determined by ParameterInfo
            Container.RegisterType<Examples.Required.TestTypeNamed<string>>(
                new InjectionConstructor(new ResolvedParameter()));

            // Resolve Required, Named dependency
            var instance = Container.Resolve<Examples.Required.TestTypeNamed<string>>();

            // Verify resolved named contract
            Assert.AreEqual(NamedString, instance.DependencyCtor);
        }

        #endregion
    }
}
