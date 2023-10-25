using Microsoft.AspNetCore.Mvc;
using coreMvcFundamentals.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace coreMvcFundamentals.Controllers
{
    public class CustomerController : Controller
    {
        //public static List<Models.Customer> customers = new List<Models.Customer>()
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer(){ Id=101,Name="King", Amount=12000},
            new Customer(){ Id=102, Name="kochur",Amount=30000},
        };
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Management System";
            ViewBag.CustomerCount = customers.Count();
            ViewBag.CustomerList = customers;
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        //this is attribute method
        //this is default route for attribute routing [Route("~/")]
        //[Route ("/sample/message")]
        public IActionResult Message()
        {
            return View();
        }
    }
}
