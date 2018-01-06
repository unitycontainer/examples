using System.Collections.Generic;
using AspNetCoreExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IFooBarService _fooBarService;

        public ValuesController(IFooBarService fooBarService)
        {
            _fooBarService = fooBarService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _fooBarService.Bar();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _fooBarService.Foo(id);
        }
    }
}
