using Microsoft.AspNetCore.Mvc;
using Pierwszy.Models;
using System.Data;
using System.Diagnostics;

namespace Pierwszy.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = "Anna";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzień dobry" : "Dobry wieczór";

            Dane[] osoby = 
            {
                new Dane { Name = "Anna", Surname = "Nowak" }, 
                new Dane { Name = "Jan", Surname = "Nowak" }, 
                new Dane { Name = "Mateusz", Surname = "Kowalski" } 
            };

            return View(osoby);
        }

        public IActionResult UrodzinyForm()
        {
            return View();
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"witaj {urodziny.Imie} {DateTime.Now.Year - urodziny.Rok}";
            return View();
        }
        public IActionResult Calculator(Calculator calculator)
        {
            if(calculator.Operation == 1)
            {
                ViewBag.result = $"{calculator.FirstNumber + calculator.SecondNumber}";
            }else if (calculator.Operation == 2)
            {
                ViewBag.result = $"{calculator.FirstNumber - calculator.SecondNumber}";
            }else if (calculator.Operation == 3)
            {
                ViewBag.result = $"{calculator.FirstNumber * calculator.SecondNumber}";
            }else if (calculator.Operation == 4)
            {
                ViewBag.result = $"{calculator.FirstNumber / calculator.SecondNumber}";
            }
            else
            {
                ViewBag.result = "";
            }

            return View();
        }

        public IActionResult CalculatorForm()
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