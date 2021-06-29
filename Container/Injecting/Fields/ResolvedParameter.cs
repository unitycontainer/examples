using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity.Injection;
using Unity;

namespace Injecting
{
    public partial class Fields
    {
        #region ResolvedParameter()

        [TestMethod(As_Annotated), TestProperty(PARAMETER, nameof(ResolvedParameter))]
        public void With_ResolvedParameter()
        {
            // Inject field with value resolved from container with contract
            // determined by FieldInfo
            Container.RegisterType<Examples.Implicit.TestType<string>>(
                new InjectionField(FieldName, new ResolvedParameter()));

            // Resolve with non attributed dependency
            var instance = Container.Resolve<Examples.Implicit.TestType<string>>();

            // By default resolved unnamed contract
            Assert.AreEqual(RegisteredString, instance.DependencyField);
        }


        [TestMethod(As_Annotated_Named), TestProperty(PARAMETER, nameof(ResolvedParameter))]
        public void Named_With_ResolvedParameter()
        {
            // Inject field with value resolved from container with contract
            // determined by FieldInfo
            Container.RegisterType<Examples.Required.TestTypeNamed<string>>(
                new InjectionField(FieldName, new ResolvedParameter()));

            // Resolve Required, Named dependency
            var instance = Container.Resolve<Examples.Required.TestTypeNamed<string>>();

            // Verify resolved named contract
            Assert.AreEqual(NamedString, instance.DependencyField);
        }

        #endregion
    }
}
