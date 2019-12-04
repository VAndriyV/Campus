using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Campus.WebUI.Controllers
{
    public class LectorSubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}