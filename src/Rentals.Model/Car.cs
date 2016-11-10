using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentals.Model
{
    public class Car
    {        
        public Guid Id { get; set; }
       
        public string Description { get; set; }
      
        public string Color { get; set; }
      
        public int Year { get; set; }
       
        public decimal RentalPrice { get; set; }
      
        public bool CurrentlyRented { get; set; }
    }
}
