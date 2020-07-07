using Currency.DAL.Repositories;
using CurrencyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace CurrencyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyRepository _currencyRepository;

        public HomeController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IActionResult Index()
        {
            var allCurrencyBy5Minuts =  _currencyRepository.GetCurrenciesByPeriod(TimeSpan.FromMinutes(5)).Result;
            var allCurrencyBy15Minuts = _currencyRepository.GetCurrenciesByPeriod(TimeSpan.FromMinutes(15)).Result;
            var allCurrencyBy30Minuts = _currencyRepository.GetCurrenciesByPeriod(TimeSpan.FromMinutes(30)).Result;
            var allCurrencyBy1Hour = _currencyRepository.GetCurrenciesByPeriod(TimeSpan.FromHours(1)).Result;

            currencyBy5MinutsModelGroup = new CurrencyGrouped
            {
                CurrencyCode = 
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
