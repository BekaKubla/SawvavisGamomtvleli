using Microsoft.AspNetCore.Mvc;
using FuelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Controllers
{
    public class FuelController :Controller
    {
        public IActionResult MapAndGasoline()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PerHundredKm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PerHundredKm(FuelProps model)
        {
            if (ModelState.IsValid)
            {
                //Burn per 100 kilometers
                model.Result = model.LitreGasoline * 100 / model.Kilometers;
                model.Result = Convert.ToDouble(model.Result.ToString("0.00"));
                return View(model);
            }
            return View(model);
        }
        
    }
}
