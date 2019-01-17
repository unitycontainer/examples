using System;
using System.Reflection;
using Unity.Builder;
using Unity.Resolution;

namespace BuildPlanExample
{
    public static class FooBuildPlanPolicy
    {

        public static ResolveDelegate<BuilderContext> GetResolver(ref BuilderContext context)
        {
            // Resolve requested type
            var argument = context.Type.GetTypeInfo().GenericTypeArguments[0];
            var name = context.Name;
            var typeToBuild = typeof(Foo<>).GetTypeInfo().MakeGenericType(argument);

            // Create Foo
            return (ref BuilderContext c) => Activator.CreateInstance(typeToBuild, c.Resolve(argument, name));
        }
    }
}
