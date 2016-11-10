using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentals.Model
{
    public class Reservation
    {        
        public Guid Id { get; set; }
             
        public string AccountId { get; set; }
              
        public Guid CarId { get; set; }
                
        public DateTime RentalDate { get; set; }
             
        public DateTime ReturnDate { get; set; }
    }
}
