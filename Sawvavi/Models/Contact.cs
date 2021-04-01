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
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ელ-ფოსტის ფორმატი არასწორია")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "ველის შევსება აუცილებელია")]
        public string Subject { get; set; }
    }
}
