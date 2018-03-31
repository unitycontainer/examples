using Unity.Extension;
using Unity.Policy;

namespace BuildPlanExample
{
    public class FooUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            // Register policy
            
            // Note name of the registration! It tells Unity that this policy 
            // applies to ALL resolutions of the type regardless of requested name.
            // In other words it creates 'Built-In' registration similar to Lazy or IEnumerable.
            Context.Policies.Set(typeof(IFoo<>), string.Empty, typeof(IBuildPlanPolicy), new FooBuildPlanPolicy());
        }
    }
}
