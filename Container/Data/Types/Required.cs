using Unity;


namespace Examples.Required
{
    public class TestType<TDependency>
    {
        public TestType([Dependency] TDependency dependency) => DependencyCtor = dependency;

        public void TestMethod([Dependency] TDependency dependency) => DependencyMethod = dependency;

        [Dependency]
        public TDependency DependencyField;
        
        [Dependency]
        public TDependency DependencyProperty { get; set; }
        
        public TDependency DependencyCtor { get; private set; }
        public TDependency DependencyMethod { get; private set; }
    }

    public class TestTypeNamed<TDependency>
    {
        public TestTypeNamed([Dependency(PatternBase.Name)] TDependency dependency) => DependencyCtor = dependency;

        public void TestMethod([Dependency(PatternBase.Name)] TDependency dependency) => DependencyMethod = dependency;

        [Dependency(PatternBase.Name)]
        public TDependency DependencyField;

        [Dependency(PatternBase.Name)]
        public TDependency DependencyProperty { get; set; }

        public TDependency DependencyCtor { get; private set; }
        public TDependency DependencyMethod { get; private set; }
    }
}
