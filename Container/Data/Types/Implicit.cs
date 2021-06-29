namespace Examples.Implicit
{
    #region Baseline

    public class TestType<TDependency>
    {
        public TestType(TDependency dependency) => DependencyCtor = dependency;

        public void TestMethod(TDependency dependency) => DependencyMethod = dependency;


        public TDependency DependencyField;
        public TDependency DependencyProperty { get; set; }
        public TDependency DependencyCtor { get; private set; }
        public TDependency DependencyMethod { get; private set; }
    }

    #endregion
}
