using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141_Ajax_16蔡文楷.Controllers
{
    public class HWController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
