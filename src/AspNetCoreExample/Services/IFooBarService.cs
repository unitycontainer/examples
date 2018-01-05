using System.Collections.Generic;

namespace AspNetCoreExample.Services
{
    public interface IFooBarService
    {
        string Foo(int a);
        IEnumerable<string> Bar();
    }
}