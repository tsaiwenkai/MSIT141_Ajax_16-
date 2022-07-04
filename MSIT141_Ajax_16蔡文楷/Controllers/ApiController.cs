using Microsoft.AspNetCore.Mvc;
using MSIT141_Ajax_16蔡文楷.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141_Ajax_16蔡文楷.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;

        public ApiController(DemoContext conetxt)
        {
            _context = conetxt;
        }
        
        public IActionResult Index(User user)
        {
            
            //System.Threading.Thread.Sleep(5000);
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            return Content($"<h1>{user.name}你好,你的年齡是{user.age}<h1>","text/html",System.Text.Encoding.UTF8);
        }
    }
}
