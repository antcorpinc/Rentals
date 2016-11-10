using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rentals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentals.Data
{
    public class RentalContext : IdentityDbContext<RentalUser>
    {
        private IConfigurationRoot _config;

        public RentalContext(IConfigurationRoot config , DbContextOptions options)
        :base(options)
        {
            _config = config;
        }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override  void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlServer(_config["ConnectionStrings:RentalsContextConnection"], b => b.MigrationsAssembly("Rentals"));
            
        }

    }
}
