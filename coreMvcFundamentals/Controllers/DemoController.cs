using coreMvcFundamentals.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreMvcFundamentals.Controllers
{
    public class DemoController : Controller

    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){Id=101,Name="King",Amount=12000},
            new Customer(){Id=102,Name="Kochur",Amount=20000},
        };
        //This is ViewBag Data
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Management System";
            ViewBag.CustomerCount = customers.Count();
            ViewBag.CustomerList = customers;
            return View();
        }
        //This is ViewData
        public IActionResult Details()
        {
            ViewData["Message"] = "This is View Data Customer Management System";
            ViewData["CustomerCount"] = customers.Count();
            ViewData["CustomerList"] = customers;

            return View();
        }
        //This is TempData
        public IActionResult Method1()
        {
            TempData["Message"] = "This is TempData Customer managemnt System";
            TempData["CustomerCount"] = customers.Count();
            TempData["CustomerList"] = customers;
            return View();
        }
        public IActionResult Method2()
        {
            if (TempData["Message"] == null)
                return RedirectToAction("Index");
            TempData["Message"] = TempData["Message"].ToString();

            return View();
        }

        //this Controller is useing for session. //That is a Login Registration
        public IActionResult Login()
        {
            //Here I want to store Username to this login iteration
            //so I will SetString(),GetString() method because These will help to store the
            //values into the session. //username is Key and Bhawna is value

            HttpContext.Session.SetString("username", "Bhawna");
            
            //I wantedto travell another action method or another view.
            //the use RedirectToAction() instead of View()
            //Here "Success" is a method
            return RedirectToAction("Success");
        }
        //creating a Success method
        public IActionResult Success()
        {
            //what ever value i want to get in to the username that should be 
            //coming from the session
            ViewBag.Username = HttpContext.Session.GetString("username");
            
            
            return View();
        }
        //This is logout method
        public IActionResult Logout()
        {
            //whatever key you would to remove.Give the name.
            HttpContext.Session.Remove("Username");

         //post that redirect to action.Which page will show .Give the Action method
            return RedirectToAction("Index");
        }

        //how to pass Query String:
        //Request Url:http://localhost:5134/Demo/QueryTest
        //Request Url:http://localhost:5134/Demo/QueryTest?name=Bhawna%20Gunwani
        //Query String Method
        public IActionResult QueryTest()
        {
            string name = "King Kochur";
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
                name = HttpContext.Request.Query["name"];
            ViewBag.Name = name;
            return View();
        }


    }
}
