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
        public PriceCategory PriceCategory { get; set; }
        public string RompetrolPrice { get; set; }
        public string GulfPrice { get; set; }
        public string PortalPrice { get; set; }
        public string OptimaPrice { get; set; }
        public string SocarPrice { get; set; }
        public string LukoilPrice { get; set; }
    }
    public enum PriceCategory
    {
        regulari,
        evroregulari,
        premiumi,
        superi,
        dizeli,
        evrodizeli,
        binebrivigazi,
        txevadigazi
    }
}
