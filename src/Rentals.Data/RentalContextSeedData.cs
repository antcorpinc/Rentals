using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rentals.Model;

namespace Rentals.Data
{
    public class RentalContextSeedData
    {
        private RentalContext _context;
        private UserManager<RentalUser> _userManager;

        public RentalContextSeedData(RentalContext context,UserManager<RentalUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task EnsureSeedDataAsync()
        {
            if(await _userManager.FindByEmailAsync("ronit@cybage.com")==null)
            {
                var user = new RentalUser() {
                    UserName="ronithomas",
                    Email= "ronit@cybage.com"
                };

               await _userManager.CreateAsync(user, "DDdd@1234");
            }

            if(!_context.Cars.Any())
            {
                var cars = new List<Car>()
                {
                    // Info: No need to add Id -- Aitomatically added
                    new Car() {Color="Blue",Description="Merc",RentalPrice=100,Year=2000,CurrentlyRented=false },
                    new Car() {Color="Red",Description="Rolls Royce",RentalPrice=200,Year=2001,CurrentlyRented=false },
                    new Car() {Color="Silver",Description="BMW",RentalPrice=400,Year=2002,CurrentlyRented=false }
                };
                _context.Cars.AddRange(cars);
                await _context.SaveChangesAsync();
            }
        }
    }
}
