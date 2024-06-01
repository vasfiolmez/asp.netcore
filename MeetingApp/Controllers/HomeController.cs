using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            int UserCount = Repository.Users.Where(x => x.WillAttend == true).Count();
            ViewBag.Selamlama = saat > 12 ? "İyi Günler" : "Günaydın";
            // ViewBag.UserName = "Vasfi";

            var meetinginfo = new MeetingInfo()
            {
                Id = 1,
                Location = "İstanbul Kongre Merkezi",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = UserCount
            };

            return View(meetinginfo);
        }
    }
}