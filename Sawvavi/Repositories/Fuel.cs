using FuelProject.Data;
using FuelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelProject.Repositories
{
    public class Fuel : IFuel
    {
        private readonly AppDbContext _context;

        public Fuel(AppDbContext context)
        {
            _context = context;
        }

        public FuelPrice Create(FuelPrice fuelPrice)
        {
            _context.FuelPrices.Add(fuelPrice);
            return fuelPrice;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
