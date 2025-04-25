using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcSQL.Data;
using MvcSQL.Models;

namespace MvcSQL.Controllers
{
    // [Route("[controller]")]
    public class StudentController : Controller
    
    {
        private readonly ApplicationDBContext _db;
        private readonly ILogger<StudentController> _logger;
       public StudentController(ApplicationDBContext db, ILogger<StudentController> logger)
    {
    _db = db;
    _logger = logger;
    }
       
        
        // private string? s1;

       

        public IActionResult Index()
        {
            Student sd1 = new Student();

            IEnumerable <Student> allStudnet =_db.Student;
            
                 return View(allStudnet);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }

        // Get Method defaule
        public IActionResult Create()
        {
            return View();
        }

        // public IActionResult ShowScore (int id)
        // {
        //     return Content($"{id}  of Sd");
        // }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Student.Add(obj);
                 _db.SaveChanges();
                 return RedirectToAction("Index");
            }
            return View(obj);
        }



    public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Edit(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Student.Update(obj);
                 _db.SaveChanges();
                 return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            // ค้นหาข้อมูลจากฐานข้อมูล
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Student.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
         }
    

    

    }
}