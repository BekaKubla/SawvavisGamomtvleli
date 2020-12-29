using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sawvavi.Models
{
    public class SawvaviProp
    {
        [Display(Name ="მანძილი/კმ")]
        public double Kilometri { get; set; }
        [Display(Name ="მანქანის  წვა ლ/100კმ")]
        public double ManqanisWva { get; set; }
        [Display(Name ="საბოლოო შედეგი ")]
        public double SabolooShedegi { get; set; }
        [Display(Name ="ლიტრი საწვავი")]
        public double LitriSawvavi { get; set; }

    }
}
