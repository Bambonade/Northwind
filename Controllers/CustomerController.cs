using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
    public class CustomerController : Controller
    {
        // this controller depends on the BloggingRepository
        private NorthwindContext _dataContext;
        public CustomerController(NorthwindContext db) => _dataContext = db;

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_dataContext.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    ModelState.AddModelError("", "Company Name must be unique");
                }
                else
                {
                    _dataContext.AddCustomer(customer);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }