using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Models
{
    public class Ganbajeba
    {
        public int Year { get; set; }
        public string Size { get; set; }
        public double Aqcizi { get; set; }
        public double Gadasaxadi { get; set; }
        public string AqciziInString { get; set; }
        public string GadasaxadiInString { get; set; }
        public double Jami { get; set; }
        public string JamiInString { get; set; }
        public double CurrecyUSD { get; set; }
        public double JamiInUSD { get; set; }
        public string JamiUSDInString { get; set; }
        public bool IsHybrid { get; set; }
        public bool IsRight { get; set; }

    }
}
