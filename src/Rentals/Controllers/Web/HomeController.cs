using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rentals.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentals.Controllers.Web
{
    
    public class HomeController : Controller
    {
       // private RentalContext _context;

        //public HomeController(RentalContext context)
        //{
        //    _context = context;
        //}
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
