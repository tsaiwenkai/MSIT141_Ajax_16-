using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSIT141_Ajax_16蔡文楷.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT141_Ajax_16蔡文楷.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public ApiController(DemoContext conetxt , IWebHostEnvironment hostEnvironment)
        {
            _host = hostEnvironment;
            _context = conetxt;
        }
        
        public IActionResult Index(User user)
        {
            //var q = _context.Members;
            //if(!string.IsNullOrEmpty(member.Name))
            //foreach(var meb in q)
            //{
            //    if (member.Name == meb.Name)
            //    {
            //        return Content("名字已經使用過了!!", "text/plain", System.Text.Encoding.UTF8);
            //    }
            //    else
            //    {
            //        return Content("名字無人使用!!", "text/plain", System.Text.Encoding.UTF8);
            //    }
            //}
            //return Content("請輸入名字!!", "text/plain", System.Text.Encoding.UTF8);


            //return Content("Ajax, 你好!!","text/plain", System.Text.Encoding.UTF8);
            if (String.IsNullOrEmpty(user.name))
            {
                user.name = "Ajax";
            }
            return Content($"{user.name}你好,你的年紀是{user.age}!!", "text/plain", System.Text.Encoding.UTF8);

        }
        public IActionResult Register(Member member, IFormFile file)
        {
            //檔案上傳要有實際路徑
            //C:\Users\Student\Documents\Ajax\MSIT141Site\wwwroot\uploads
            //string path = _host.ContentRootPath; //會取得專案資料夾的實際路徑

            string filepath = Path.Combine(_host.WebRootPath, "uploads", file.FileName);//會取得專案資料夾下wwwroot的實際路徑

            using (var filestring=new FileStream(filepath, FileMode.Create)) 
            {
                file.CopyTo(filestring); //儲存檔案到uploads資料夾中
            }

            //傳成2進位資料進DATA
            byte[] img = null;
            using (var memorystring = new MemoryStream())
            {
                file.CopyTo(memorystring);
                img = memorystring.ToArray();
            }

            member.FileName = file.FileName;
            member.FileData = img;

            _context.Add(member);
            _context.SaveChanges();

            string info = $"{file.FileName} - {file.ContentType} - {file.Length}";
            return Content(info, "text/plain", System.Text.Encoding.UTF8);
        }


        public IActionResult City() 
        {
            var q = _context.Addresses.Select(q => q.City).Distinct();
            return Json(q);
        
        }
        public IActionResult districts(string city)
        {
            var q = _context.Addresses.Where(q=>q.City==city).Select(q => q.SiteId).Distinct();
            return Json(q);

        }
        public IActionResult roads(string districts)
        {
            var q = _context.Addresses.Where(q => q.SiteId== districts).Select(q=>q.Road);
            return Json(q);

        }
        public IActionResult GetImageBytes(int id = 1)
        {
            Member member = _context.Members.Find(id);
            byte[] img = member.FileData;
            return File(img, "image/jpeg");
        }

    }
}
