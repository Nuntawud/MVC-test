using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcSQL.Models;

namespace MvcSQL.Controllers
{
    // [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private string? s1;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Student sd1 = new Student();
            
            sd1.Id = 1;
            sd1.Name = "Test1";
            sd1.Score = 50;

       
            
            

            var sd2 = new Student();
            sd2.Id = 2;
            sd2.Name = "Test2";
            sd2.Score = 40;
            // var sd3 = new Student();
            // return Content("Test-eiei");

            List<Student> allstudent = new List<Student>();
            allstudent.Add(sd1);
            allstudent.Add(sd2);

                 return View(allstudent);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public IActionResult ShowScore (int id)
        {
            return Content($"{id}  of Sd");
        }
    }
}