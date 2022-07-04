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
        
        public IActionResult Index(Member member)
        {
            var q = _context.Members;
            if(!string.IsNullOrEmpty(member.Name))
            foreach(var meb in q)
            {
                if (member.Name == meb.Name)
                {
                    return Content("名字已經使用過了!!", "text/plain", System.Text.Encoding.UTF8);
                }
                else
                {
                    return Content("名字無人使用!!", "text/plain", System.Text.Encoding.UTF8);
                }
            }
            return Content("請輸入名字!!", "text/plain", System.Text.Encoding.UTF8);
        }
    }
}
