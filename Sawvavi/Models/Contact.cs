using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "ველის შევსება აუცილებელია")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ველის შევსება აუცილებელია")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "ველის შევსება აუცილებელია")]
        public string Subject { get; set; }
    }
}
