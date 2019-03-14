using Unity;
using Unity.Wcf;

namespace WcfUnityService
{
    public class WcfServiceFactory : UnityServiceHostFactory {
        protected override void ConfigureContainer(IUnityContainer container) {
            // configure container
            container
                .RegisterType<IService1, Service1>();
        }
    }
}
