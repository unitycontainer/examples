using System;
using System.Diagnostics;
using Unity;

namespace ChildContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            var wr = CreateChild(container);

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true, true);

            Debug.Assert(false == wr.IsAlive);
        }

        static WeakReference CreateChild(IUnityContainer container)
        {
            var child = container.CreateChildContainer();
            var wr = new WeakReference(child);
            child.Dispose();
           
            
            return wr;
        }
    }
}
