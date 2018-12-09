using System.Linq;
using System.Reflection;
using Unity;
using Unity.Builder;
using Unity.ObjectBuilder.BuildPlan.DynamicMethod;
using Unity.Policy;
using Unity.Resolution;
using Unity.Storage;

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

        public IBuildPlanPolicy CreatePlan<TBuilderContext>(ref TBuilderContext context, INamedType buildKey)
            where TBuilderContext : IBuilderContext
        {
            // Make generic factory method for the type
            var typeToBuild = buildKey.Type.GetTypeInfo().GenericTypeArguments.First();
            var factoryMethod =
                _factoryMethod.MakeGenericMethod(typeof(TBuilderContext), typeToBuild)
                              .CreateDelegate(typeof(ResolveDelegate<TBuilderContext>));
            // Create policy
            var creatorPlan = new DynamicMethodBuildPlan(factoryMethod);

            // Register BuildPlan policy with the container to optimize performance
            _policies.Set(buildKey.Type, string.Empty, typeof(IBuildPlanPolicy), creatorPlan);

            return creatorPlan;
        }

        private static object FactoryMethod<TBuilderContext, TResult>(ref TBuilderContext context)
            where TBuilderContext : IBuilderContext
        {
            // Resolve requested type
            var service = (TResult)context.Container.Resolve(typeof(TResult), context.BuildKey.Name);

            // Create Foo
            return new Foo<TResult>(service);
        }
    }
}
