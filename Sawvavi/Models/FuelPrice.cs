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
        public string Price { get; set; }
        [Display(Name ="საწვავის სახელი")]
        public string FuelName { get; set; }
    }
}
