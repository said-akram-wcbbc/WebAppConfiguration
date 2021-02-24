using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppConfiguration.Models;

namespace WebAppConfiguration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Displayname = _configuration["displayname"];
            ViewBag.Adapters = GetConfigurationArraySection(_configuration, "adapters");

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

        private IEnumerable<string> GetConfigurationArraySection(IConfiguration configuration, string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName) || configuration == null)
            {
                return new List<string>();
            }

            return configuration.GetSection(sectionName)?.GetChildren()?.Select(c => c.Value);
        }
    }
}
