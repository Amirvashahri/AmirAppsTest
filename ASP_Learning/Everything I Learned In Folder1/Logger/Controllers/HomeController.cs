using Logger.Models;
using Logger.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_logger.Log(LogLevel.Information, "Request Start");
            _logger.LogInformation("Hmmmmm");

            if (1 == 1)
                _logger.LogWarning("File Not Found");

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                _logger.LogError(LogEvent.SpecificErrorOccurred, ex, "Errorrrrrrrrr.........");
            }

            _logger.LogError(LogEvent.SomeErrorOccurred, "Errorrrrrrrrr.........");

            int a = 10;
            int b = 20;
            int c = a + b;
            _logger.LogDebug("The sum of two numbers");
            _logger.LogTrace($" c = {c}");

            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Can Not Connect Database...");
            }
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
