﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mohammadi.Controllers.sa;
using mohammadi.Models;
using mohammadi.Models.ViewModel;

namespace mohammadi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICrudGeneric<ProductCategory> _productCatergoryService;

        public HomeController(ILogger<HomeController> logger, ICrudGeneric<ProductCategory> productCatergoryService )
        {
            _logger = logger;
            this._productCatergoryService = productCatergoryService;
        }

        public IActionResult Index()
        {
            var list = new List<String>();
            list.Add("hassan");
            list.Add("sharafi");
            return View(list);
        }

        public IActionResult Privacy()
        {
        
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>
        /// برگرداندن لیستی از دسته بندی ها به همراه محصولات آن
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProductsPartial()
        {
            var pcs = _productCatergoryService.GetList().Include(pc => pc.Products).ToList();
            return PartialView("_productList", pcs);
        }
    }
}
