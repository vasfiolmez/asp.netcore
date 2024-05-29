
using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        var kurs = new Course();
        kurs.Id = 1;
        kurs.Title = "Aspnet Core Kursu";
        kurs.Description = "Güzel bir kurs";

        return View(kurs);
    }

    public IActionResult List()
    {
        var kurslar = new List<Course>()
        {
           new Course(){ Id=1,Title="asp.net kursu",Description="güzeldi"},
           new Course(){ Id=2,Title="php kursu",Description="güzeldi"},
           new Course(){ Id=3,Title="django kursu",Description="güzeldi"}
        };
        return View("CourseList", kurslar);
    }
}