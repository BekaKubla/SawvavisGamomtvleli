using FuelProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Controllers
{
    public class GanbajebaController:Controller
    {
        private void SizeYear()
        {
            var a = 2021;
            double b = 0.0;
            var yearList = new List<int>();
            var sizeList = new List<string>();
            for (int i = 0; i < 57; i++)
            {
                yearList.Add(a - i);
            }
            for (var i = 0; i < 63; i++)
            {
                b = b + 0.1;
                var c = string.Format("{0:0.0}", b);
                sizeList.Add(c);
            }
            ViewBag.yearList = yearList;
            ViewBag.sizeList = sizeList;
        }
        private static void Aqcizi(Ganbajeba ganbajeba)
        {
            if (ganbajeba.Year >= 2019 || ganbajeba.Year == 2009)
            {
                ganbajeba.Aqcizi = 1.5 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);

            }
            else if (ganbajeba.Year >= 2013 && ganbajeba.Year <= 2015)
            {
                ganbajeba.Aqcizi = 0.8 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2011)
            {
                ganbajeba.Aqcizi = 1.1 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2017)
            {
                ganbajeba.Aqcizi = 1.2 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2010)
            {
                ganbajeba.Aqcizi = 1.3 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2018)
            {
                ganbajeba.Aqcizi = 1.4 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2008)
            {
                ganbajeba.Aqcizi = 1.8 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2007)
            {
                ganbajeba.Aqcizi = 2.1 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else if (ganbajeba.Year == 2016)
            {
                ganbajeba.Aqcizi = 1.0 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
            else
            {
                ganbajeba.Aqcizi = 2.4 * Convert.ToDouble(ganbajeba.Size) * 1000;
                ganbajeba.AqciziInString = string.Format("{0:0}", ganbajeba.Aqcizi);
            }
        }
        private static void Gadasaxadi(Ganbajeba ganbajeba)
        {
            if (ganbajeba.Year == 2021)
            {
                ganbajeba.Gadasaxadi = (Convert.ToDouble(ganbajeba.Size) * 1000 * 0.05);
            }
            else
            {
                int dateNow = 2021;
                ganbajeba.Gadasaxadi = (Convert.ToDouble(ganbajeba.Size) * 1000 * 0.05) + (Convert.ToDouble(ganbajeba.Size) * 1000 * (dateNow - ganbajeba.Year) * 0.0025);
                ganbajeba.GadasaxadiInString=string.Format("{0:0}", ganbajeba.Gadasaxadi);
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            SizeYear();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Ganbajeba ganbajeba)
        {
            if (ModelState.IsValid)
            {
                Aqcizi(ganbajeba);
                Gadasaxadi(ganbajeba);
                return RedirectToAction("Result");
            }
            SizeYear();
            return View();
        }
    }
}
