using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AspNetCoreExample.Services
{
    public class FooBarService : IFooBarService
    {
        private readonly ILogger<FooBarService> _logger;

        public FooBarService(ILogger<FooBarService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<string> Bar()
        {
            _logger.LogInformation($"Method {nameof(Bar)}");

            return new[] { "value1", "value2" };
        }

        public string Foo(int a)
        {
            _logger.LogInformation($"Method {nameof(Foo)}, argument {a}");

            return (a * a).ToString();
        }
    }
}
