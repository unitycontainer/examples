using ASP.Net.Unity.Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unity;

namespace ASP.Net.Unity.Example.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IUnityContainer container)
        {
            // Verify controller was created by Unity container
            Debug.Assert(null != container);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
