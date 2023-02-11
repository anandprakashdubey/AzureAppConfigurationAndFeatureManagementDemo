using AzureAppConfigurationAndFeatureManagementDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using System.Diagnostics;

namespace AzureAppConfigurationAndFeatureManagementDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _feature;

        public HomeController(ILogger<HomeController> logger
            , IConfiguration configuration
            , IFeatureManager feature)
        {
            _logger = logger;
            _configuration = configuration;
            _feature = feature;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.IsFeatureEnable = await _feature.IsEnabledAsync("beta")
                ? true
                : false; 
            
            ViewData["AzureAppConfigValue"] = _configuration["AzureAppConfigurationKey"].ToString();
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