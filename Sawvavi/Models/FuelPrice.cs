using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Models
{
    public class FuelPrice
    {
        public int ID { get; set; }
        public DateTime DateTimeNow { get; set; }
        public FuelCategory FuelCategory { get; set; }
        public double RompetrolPrice { get; set; }
        public double GulfPrice { get; set; }
        public double PortalPrice { get; set; }
        public double OptimaPrice { get; set; }
        public double SocarPrice { get; set; }
        public double LukoilPrice { get; set; }
    }
    public enum FuelCategory
    {
        superi,
        premiumi,
        regulari,
        evroregulari,
        dizeli,
        evrodizeli,
        txevadigazi,
        bunebrivigazi

    }
}
