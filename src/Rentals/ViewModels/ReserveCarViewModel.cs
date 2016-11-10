using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rentals.ViewModels
{
    public class ReserveCarViewModel
    {
        [Required]
        [Display(Name = "Pick Up Date")]
        public DateTime PickUpDate { get; set; }

        [Required]
        [Display(Name ="Return Date")]
        public DateTime ReturnDate{ get; set; }
    }
}
