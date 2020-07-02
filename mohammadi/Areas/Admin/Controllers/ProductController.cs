using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace mohammadi.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ICrudGeneric<Product> _productService;
        private readonly ICrudGeneric<ProductCategory> _productCategoryService;

        public ProductController(ICrudGeneric<Product> productService , ICrudGeneric<ProductCategory> productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }

        #region لیست محصولات
        public IActionResult Index()
        {
            var result = _productService.GetList().ToList();
            return View(result);
        }
        #endregion
        #region  جزئیات

        #endregion
        #region ایجاد محصولات
        public IActionResult Create(short? id)
        {
            var producCategory = _productCategoryService.GetList().AsNoTracking().Select(c => new SelectOptionViewModel { 
                Key = c.Id.ToString(), 
                Value = c.Name
            }).ToList();
          
            var model = _productService.GetList().AsNoTracking().FirstOrDefault(p => p.Id == id) ?? new Product();
            ViewBag.ProductCategories = new SelectList(producCategory, "Key", "Value", model.ProductCategoryId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile != null && product.ImageFile.Length != 0)
                {
                    product.ImageName =await _productService.SaveFile(product.ImageFile);
                }
                if (product.Id == 0)
                    _productService.Create(product);
                else
                    _productService.Upadate(product);
                return RedirectToAction("Index");

            }
            return View(product);

        }

        #endregion

        #region  حذف

        public IActionResult Delete(short id)
        {

            _productService.Delete(id);
            return RedirectToAction("index");

        }
        #endregion


    }
}