using System.Linq;
using Application;
using Application.Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mohammadi.Controllers.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductViewComponent(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _productCategoryService.GetQuery().AsNoTracking().Include(pc => pc.Products).ToList();
            return View(model);
        }


    }
}