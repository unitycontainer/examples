using Unity;

namespace Examples
{
    public abstract partial class PatternBase
    {
        #region Fields

        protected IUnityContainer Container;
        
        #endregion


        #region Scaffolding

        public virtual void TestInitialize()
        {
            Container = new UnityContainer();

            Container.RegisterInstance(RegisteredInt)
                     .RegisterInstance(Name, NamedInt)
                     .RegisterInstance(RegisteredString)
                     .RegisterInstance(Name, NamedString)
                     .RegisterInstance(RegisteredUnresolvable)
                     .RegisterInstance(Name, NamedUnresolvable)
                     .RegisterInstance(typeof(string), Null, (object)null)
                     .RegisterInstance(typeof(Unresolvable), Null, (object)null)
                     .RegisterInstance(RegisteredBool)
                     .RegisterInstance(RegisteredLong)
                     .RegisterInstance(RegisteredShort)
                     .RegisterInstance(RegisteredFloat)
                     .RegisterInstance(RegisteredDouble)
                     .RegisterInstance(RegisteredType)
                     .RegisterInstance(RegisteredICloneable)
                     .RegisterInstance(RegisteredDelegate);
        }

        #endregion

    }
}


