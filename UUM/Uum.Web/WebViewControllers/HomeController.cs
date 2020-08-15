using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UUM.Model.ViewModels;

namespace UUM.WEB.WebViewControllers
{
    /// <summary>
    /// Home page controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy() => View();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
