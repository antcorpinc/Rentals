﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rentals.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentals.Controllers.Web
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CurrentReservation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReserveCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReserveCar(ReserveCarViewModel vm)
        {
            return View();
        }
    }
}
