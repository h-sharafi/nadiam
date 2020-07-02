using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace mohammadi.Areas.Admin.Controllers
{

    public class HomeController : BaseController
    {
        private readonly ICrudGeneric<Product> _productService;

        public HomeController(ICrudGeneric<Product> productService)
        {
            this._productService = productService;
        }
      


        public IActionResult Index()
        {
            var products = _productService.GetList().ToList();
            return View(products);
        }

    }
}