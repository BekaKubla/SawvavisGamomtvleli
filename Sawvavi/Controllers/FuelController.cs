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
        [Route("Ruka")]
        public IActionResult MapAndGasoline()
        {
            return View();
        }
        
    }
}
