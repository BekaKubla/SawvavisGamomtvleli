using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Models
{
    public class FuelProps
    {
        [Display(Name ="მანძილი/კმ")]
        //[Display(Name=Distance/Km)]
        [Range(0,99999,ErrorMessage ="ინფორმაცია არასწორია")]
        public double Kilometers { get; set; }
        [Display(Name ="მანქანის  წვა ლ/100კმ")]
        //[DisplayName(Name="Gasoline burn L/100Km")]
        [Range(0, 99999, ErrorMessage = "ინფორმაცია არასწორია")]
        public double BurningGasoline { get; set; }
        [Display(Name ="საბოლოო შედეგი ")]
        //[Display(Name="Result")]
        public double Result { get; set; }
        [Range(0, 99999, ErrorMessage = "ინფორმაცია არასწორია")]
        [Display(Name ="ლიტრი საწვავი")]
        //[Display(Name="Liters of fuel")]
        public double LitreGasoline { get; set; }

    }
}
