using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace AzureAppConfigurationAndFeatureManagementDemo.Controllers
{
    [FeatureGate("beta")]
    public class FeatureTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
