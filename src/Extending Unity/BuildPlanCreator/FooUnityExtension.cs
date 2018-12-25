using Unity.Extension;
using Unity.Policy;

namespace BuildPlanCreatorExample
{
    public class FooUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            // Register policy

            // Note name of the registration! It tells Unity that this policy 
            // applies to ALL resolutions of the type regardless of requested name.
            // In other words it creates 'Built-In' registration similar to Lazy or IEnumerable.
            var instance = new FooBuildPlanCreatorPolicy(Context.Policies);
            Context.Policies.Set(typeof(IFoo<>), string.Empty, typeof(ResolveDelegateFactory), (ResolveDelegateFactory)instance.GetResolver);
            Context.Policies.Set(typeof(Foo<>), string.Empty,  typeof(ResolveDelegateFactory), (ResolveDelegateFactory)instance.GetResolver); // Optional
        }
    }
}
