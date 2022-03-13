using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ring_120322.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ring_120322.Controllers
{
    public class HomeController : Controller
    {
        public IRingCollection C;

        public HomeController(IRingCollection c)
        {
            C = c;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            C.Add(username);
            return View((object)username);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
