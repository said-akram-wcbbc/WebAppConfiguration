using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using WebAppConfiguration.Models;

namespace WebAppConfiguration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortalOptions _portalOptions;
        private readonly IEnumerable<AdapterOptions> _adapterOptions;

        public HomeController(ILogger<HomeController> logger,
            IOptions<PortalOptions> portalOptions,
            IOptionsSnapshot<AdapterOptions> adapterOptionsAccessor)
        {
            _logger = logger;
            _portalOptions = portalOptions.Value;
            _adapterOptions = GetAdpters(_portalOptions?.Adapters, adapterOptionsAccessor);
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                PortalOptions = _portalOptions,
                Adapters = _adapterOptions
            };
            return View(viewModel);
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

        private IEnumerable<AdapterOptions> GetAdpters(IEnumerable<string> adapterNames,
            IOptionsSnapshot<AdapterOptions> adapterOptionsAccessor)
        {
            var adapters = new List<AdapterOptions>();

            foreach (var adapter in adapterNames)
            {
                adapters.Add(adapterOptionsAccessor.Get(adapter));
            }

            return adapters;
        }
    }
}