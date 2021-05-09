using FuelProject.Models;
using FuelProject.Repositories;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;

namespace FuelProject.Controllers
{
    public class ScrapingController : Controller
    {
        private readonly IFuel _fuel;

        public ScrapingController(IFuel fuel)
        {
            _fuel = fuel;
        }
        [Route("Sawvavi")]
        public IActionResult FuelPrice(FuelPrice fuelPrice)
        {
            var getPrices = _fuel.GetPrices(fuelPrice);
            var getCurrentData = getPrices.GroupBy(x => x.FuelCategory).Select(x => x.OrderByDescending(y => y.DateTimeNow).First());
            ViewBag.DateTime = getCurrentData.First().DateTimeNow.ToString("yyyy-MM-dd HH:mm");
            return View(getCurrentData);
        }

    }
}
