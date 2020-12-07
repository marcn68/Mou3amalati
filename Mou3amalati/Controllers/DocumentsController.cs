using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mou3amalati.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
