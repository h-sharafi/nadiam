using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace mohammadi.Areas.Admin.Controllers
{

    public class HomeController : BaseController
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }



        public IActionResult Index()
        {
            var products = _productService.GetQuery().ToList();
            return View(products);
        }

    }
}