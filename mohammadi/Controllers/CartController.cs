using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service;
using Domain.ViewModel;
using mohammadi.Infrastructure;
using mohammadi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mohammadi.Controllers {
    public class CartController : Controller {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICartService _cartService;
        public CartController (IProductService productService, ICartService cartService, IHttpContextAccessor  httpContext ) {
            this._cartService = cartService;
            this._productService = productService;
            _httpContext = httpContext;
        }

        public IActionResult Index (string key, string value, int? expireTime) {
            return View ();
        }

        // [HttpPost]
        public async Task<IActionResult> AdToCart (short id) {

           var result = await _cartService.UpdateCart(_httpContext , id);

            // return new JsonResult (new {
            //     result = result
            // });
            return Redirect("/");
        }
    }
}