using System.Linq;
using System.Reflection;
using Unity.Builder;
using Unity.ObjectBuilder.BuildPlan.DynamicMethod;
using Unity.Policy;

namespace BuildPlanCreatorExample
{
    public class FooBuildPlanCreatorPolicy : IBuildPlanCreatorPolicy
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

        public IBuildPlanPolicy CreatePlan(ref BuilderContext context, INamedType buildKey)
        {
            // Make generic factory method for the type
            var typeToBuild = buildKey.Type.GetTypeInfo().GenericTypeArguments.First();
            var factoryMethod =
                _factoryMethod.MakeGenericMethod(typeToBuild)
                              .CreateDelegate(typeof(ResolveDelegate<BuilderContext>));
            // Create policy
            var creatorPlan = new DynamicMethodBuildPlan(factoryMethod);

            // Register BuildPlan policy with the container to optimize performance
            _policies.Set(buildKey.Type, string.Empty, typeof(IBuildPlanPolicy), creatorPlan);

            return creatorPlan;
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
