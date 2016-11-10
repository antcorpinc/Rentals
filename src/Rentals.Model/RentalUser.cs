using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentals.Model
{
    public class RentalUser :IdentityUser
    {
        public RentalUser()
        {
        }
    }
}
