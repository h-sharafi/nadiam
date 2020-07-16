using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Persistence;

namespace mohammadi.Areas.Admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }
        public IActionResult Index()
        {
            var result = _productCategoryService.GetQuery().ToList();
            return View(result);
        }
        #region افزودن دسته بندی
        public IActionResult Create(short? id)
        {
            var model = id == null ? new ProductCategory() : _productCategoryService.GetQuery().FirstOrDefault(p => p.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productCategoryService.Create(productCategory);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(productCategory);
                }
            }
            return View(productCategory);
        }
        #endregion
        #region حذف 
        [HttpPost]
        public IActionResult Delete(short id)
        {
            var result = true;
            try
            {
                _productCategoryService.Delete(id);
            }
            catch
            {
                result = false;
            }
            return new JsonResult(new
            {
                result = result
            });
        }
        #endregion
    }
}