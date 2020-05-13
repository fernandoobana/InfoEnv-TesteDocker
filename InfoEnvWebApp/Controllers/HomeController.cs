using InfoEnvWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using System;
using Microsoft.Extensions.Configuration;

namespace InfoEnvWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _conf;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }

        public IActionResult Index()
        {
            return View(new Info()
            {
                OSVersion = System.Environment.OSVersion.ToString(),
                Framework = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName,
                Date = DateTime.Now,
                VariavelAmbiente = System.Environment.GetEnvironmentVariable("INFO_VAR"),
                VariavelAppSetting = _conf.GetSection("Teste").GetValue<string>("Complex")
            });
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

    public class Info
    {
        public DateTime Date { get; set; }

        public string OSVersion { get; set; }
        public string Framework { get; set; }
        public string VariavelAmbiente { get; set; }
        public string VariavelAppSetting { get; set; }
    }
}
