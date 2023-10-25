using coreMvcFundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace coreMvcFundamentals.Controllers
{
    public class Practice1Controller : Controller
    {
        public static List<InfoModel> users = new List<InfoModel>()
        {
            new InfoModel() { Id=200,Name="Bhabna Gunwani",Amount=2500 },
            new InfoModel() { Id=201,Name="Prity Lata", Amount=3500 },
            new InfoModel() { Id=203, Name="Angelical" ,Amount=1000 },
            new InfoModel() { Id=204, Name="Ada", Amount=5000 }

        };

        public IActionResult Info()
        {
            ViewBag.Message = "This is School Management System.";
            ViewBag.UserCount=users.Count();
            ViewBag.UserList = users;
            return View();

        }
        public IActionResult CallMethod()
        {
            if (ViewBag.Message == null)
                return RedirectToAction("Index");
            ViewBag.Message = ViewBag.Message.ToString();

            return View();
        }

       
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
