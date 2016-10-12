using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        List<Customer> customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "Mahmud"},
            new Customer { Id = 2, Name = "Hamid"},
            new Customer { Id = 3, Name = "Zia"}

        };

        // GET: Customer
        public ActionResult Index()
        {
            //List< Customer > customers = new List<Customer>()
            //{
            //    new Customer { Id = 1, Name = "Mahmud"},
            //    new Customer { Id = 2, Name = "Hamid"},
            //    new Customer { Id = 3, Name = "Zia"}

            //};

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = customers.Where(cus => cus.Id == id);
            return View(customer);
        }
    }
}