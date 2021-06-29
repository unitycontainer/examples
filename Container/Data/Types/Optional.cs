using Unity;


namespace Examples.Optional
{
    public class TestType<TDependency>
    {
        #region Constructor

        public TestType([OptionalDependency] TDependency dependency) => DependencyCtor = dependency;

        #endregion


        #region Method

        public void TestMethod([OptionalDependency] TDependency dependency) => DependencyMethod = dependency;

        #endregion


        #region Field

        [OptionalDependency]
        public TDependency DependencyField;

        #endregion


        #region Property

        [OptionalDependency]
        public TDependency DependencyProperty { get; set; }

        #endregion


        #region Dependencies

        public TDependency DependencyCtor { get; private set; }
        public TDependency DependencyMethod { get; private set; }

        #endregion
    }

    public class TestTypeNamed<TDependency>
    {
        #region Constructor

        public TestTypeNamed([OptionalDependency(PatternBase.Name)] TDependency dependency) => DependencyCtor = dependency;

        #endregion


        #region Method

        public void TestMethod([OptionalDependency(PatternBase.Name)] TDependency dependency) => DependencyMethod = dependency;

        #endregion


        #region Field

        [OptionalDependency(PatternBase.Name)]
        public TDependency DependencyField;

        #endregion


        #region Property

        [OptionalDependency(PatternBase.Name)]
        public TDependency DependencyProperty { get; set; }

        #endregion


        #region Dependencies

        public TDependency DependencyCtor { get; private set; }
        public TDependency DependencyMethod { get; private set; }

        #endregion
    }
}
