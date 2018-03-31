
using System;

namespace BuildPlanExample
{
    public interface IService
    {
        string Id { get; } 
    }

    public class Service : IService
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"ID: {Id}";
        }
    }

    public interface IFoo<T>
    {
        T Service { get; }
    }

    public class Foo<T> : IFoo<T> 
    {
        public Foo(T service)
        {
            Service = service;
        }

        public T Service { get; }

        public override string ToString()
        {
            return $"Type: {GetType()}  Service: {Service}";
        }
    }
}
