using FuelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Repositories
{
   public interface IFuel
    {
        FuelPrice Create(FuelPrice fuelPrice);
        IEnumerable<FuelPrice> GetPrices(FuelPrice fuelPrice);
        bool SaveChange();
    }
}
