using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UUM.WebAPI.Models;

namespace UUM.ApiWeb.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger properties
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Will always instantiate the log message
        /// </summary>
        /// <param name="logger">Log message</param>
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        /// <summary>
        /// Get page
        /// </summary>
        /// <returns>View page</returns>
        public IActionResult Index() => View();

        /// <summary>
        /// Get page
        /// </summary>
        /// <returns>View page</returns>
        public IActionResult Privacy() => View();

        /// <summary>
        /// Display error page
        /// </summary>
        /// <returns>Error page</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
