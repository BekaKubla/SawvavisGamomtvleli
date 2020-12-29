using Microsoft.AspNetCore.Mvc;
using Sawvavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sawvavi.Controllers
{
    public class SawvaviController :Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        public IActionResult Index(SawvaviProp model)
        {
                //რამდენის დაწვა მოუწევს კონკრეტულ კილომეტრზე
                double litriKilometrze = 100 / model.ManqanisWva;
                model.SabolooShedegi = model.Kilometri / litriKilometrze / model.ManqanisWva * model.ManqanisWva;
                model.SabolooShedegi = Convert.ToDouble(model.SabolooShedegi.ToString("0.00"));
                return View(model);
        }
        [HttpGet]
        public ActionResult IndexTwo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexTwo(SawvaviProp model)
        {

                //რამდენი წვავს ავტომობილი 100 კილომეტრზე
                model.SabolooShedegi = model.LitriSawvavi * 100 / model.Kilometri;
                model.SabolooShedegi = Convert.ToDouble(model.SabolooShedegi.ToString("0.00"));
            return View(model);
        }
        [HttpGet]
        public ActionResult MapIndex()
        {
            return View();
        }
        public ActionResult Demo1()
        {
            return View();
        }

        public ActionResult Demo2()
        {
            return View();
        }
        public ActionResult TestIndex()
        {
            return View();
        }
    }
}
