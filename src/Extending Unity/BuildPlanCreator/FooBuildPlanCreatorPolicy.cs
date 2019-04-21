using System.Linq;
using System.Reflection;
using Unity;
using Unity.Builder;
using Unity.Policy;
using Unity.Resolution;

namespace BuildPlanCreatorExample
{
    public class FooBuildPlanCreatorPolicy 
    {
        private readonly IPolicyList _policies;

        private readonly MethodInfo _factoryMethod = 
            typeof(FooBuildPlanCreatorPolicy).GetTypeInfo().GetDeclaredMethod(nameof(FactoryMethod));

        /// <summary>
        /// Factory plan to build [I]Foo type
        /// </summary>
        /// <param name="policies">Container policy list to store created plans</param>
        public FooBuildPlanCreatorPolicy(IPolicyList policies)
        {
            _policies = policies;
        }

        public ResolveDelegate<BuilderContext> GetResolver(ref BuilderContext context)
        {
            // Make generic factory method for the type
            var typeToBuild = context.Type.GetTypeInfo().GenericTypeArguments.First();
            var factoryMethod = (ResolveDelegate<BuilderContext>)
                _factoryMethod.MakeGenericMethod(typeToBuild)
                              .CreateDelegate(typeof(ResolveDelegate<BuilderContext>));

            // Register BuildPlan policy with the container to optimize performance
            _policies.Set(context.Type, typeof(ResolveDelegate<BuilderContext>), factoryMethod);

            return factoryMethod;
        }

        private static object FactoryMethod<TResult>(ref BuilderContext context)
        {
            // Resolve requested type
            var service = (TResult)context.Resolve(typeof(TResult), context.Name);

            // Create Foo
            return new Foo<TResult>(service);
        }
    }
}
