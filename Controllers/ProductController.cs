using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _dataContext;
        public ProductController(NorthwindContext db) => _dataContext = db;

        public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));
        public IActionResult Index(int id) => View(_dataContext.Products.Where(p => p.CategoryId == id && p.Discontinued == false).OrderBy(p => p.ProductName));
        public IActionResult Discounts() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
    }