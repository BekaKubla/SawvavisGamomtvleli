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
        [HttpGet]
        public IActionResult Index()
        {
            var a = 2021;
            var b = 0.1;
            var yearList = new List<int>();
            var sizeList = new List<double>();
            for (int i = 0; i < 57; i++)
            {
                yearList.Add(a - i);
            }
            ViewBag.yearList = yearList;
            for (var i = 0;i<63;i++)
            {
                sizeList.Add(b+0.1);
                b = b + 0.1;
            }
            ViewBag.sizeList = sizeList;

            //ViewBag.sizeList = new List<double>() { 0.1, 0.2, 0.3, 0.4,0.5,0.6,0.7,0.8,0.9,1.0,1.1,1.2,1.3,1.4,1.5,1.6,1.7,1.8,1.9,
            //                                        2.0,2.1,2.2,2.3,2.4,2.5,2.6,2.7,2.8,2.9,3.0,3.1,3.2,3.3,3.4,3.5,3.6,3.7,3.8,3.9,
            //                                        4.0,4.1,4.2,4.3,4.4,4.5,4.6,4.7,4.8,4.9,5.0,5.1,5.2,5.3,5.4,5.5,5.6,5.7,5.8,5.9,
            //                                        6.0,6.1,6.2,6.3};

            return View();
        }
        [HttpPost]
        public IActionResult Index(Ganbajeba ganbajeba)
        {
            if (ModelState.IsValid)
            {
                ganbajeba.Sum = ganbajeba.Size + ganbajeba.Year;
            }
            ViewBag.yearList = new List<int>() { 1965,1966,1967,1968,1969,1970,1971,1972,1973,1974,1975,1976,1977,1978,1979,1980,
                                                 1981,1982,1983,1984,1985,1986,1987,1988,1989,1990,1991,1992,1993,1994,1995,1996,
                                                 1997,1998,1999,2000,2001,2002,2003,2004,2005,2006,2007,2008,2009,2010,2011,2012,
                                                 2013,2014,2015,2016,2017,2018,2019,2020,2021};
            ViewBag.sizeList = new List<double>() { 0.1, 0.2, 0.3, 0.4,0.5,0.6,0.7,0.8,0.9,1.0,1.1,1.2,1.3,1.4,1.5,1.6,1.7,1.8,1.9,
                                                    2.0,2.1,2.2,2.3,2.4,2.5,2.6,2.7,2.8,2.9,3.0,3.1,3.2,3.3,3.4,3.5,3.6,3.7,3.8,3.9,
                                                    4.0,4.1,4.2,4.3,4.4,4.5,4.6,4.7,4.8,4.9,5.0,5.1,5.2,5.3,5.4,5.5,5.6,5.7,5.8,5.9,
                                                    6.0,6.1,6.2,6.3};
            return View();
        }
    }
}
