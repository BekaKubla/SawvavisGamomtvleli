using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Models
{
    public class FuelPrice
    {
        [Display(Name ="ფასი")]
        public string RompetrolPrice { get; set; }
        [Display(Name ="რომპეტროლი")]
        public string RompetrolName { get; set; }
        [Display(Name ="გალფი")]
        public string GulfName { get; set; }
        [Display(Name ="ფასი")]
        public string GulfPrice { get; set; }
    }
}
