﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mou3amalati.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocumentsList()
        {
            return View();
        }

        public IActionResult MyDocuments()
        {
            return View();
        }
    }
}
