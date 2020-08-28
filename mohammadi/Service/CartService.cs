using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mohammadi.Infrastructure;

namespace mohammadi.Service
{
    public interface ICartService
    {
        Task<bool> UpdateCart(IHttpContextAccessor httpChttpContextAccessorontext, short id);
    }
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        public CartService(IProductService productService)
        {
            this._productService = productService;

        }

        public async Task<bool> UpdateCart(IHttpContextAccessor httpContextAccessor, short id)
        {
            bool result = true;
            try
            {
                var product = await _productService.GetQuery().AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                List<Cart> carts = httpContextAccessor.HttpContext.Request.Get<List<Cart>>(CookieKey.cartCookie);
                if (carts == null)
                {
                    carts = new List<Cart>();
                    carts.Add(new Cart
                    {
                        Id = id,
                        Name = product.Name,
                        Count = 1,
                        Price = product.Price

                    });
                }
                else
                {
                    if (carts.Any(c => c.Id == id))
                    {
                        var exitCart = carts.FirstOrDefault(c => c.Id == id);
                        exitCart.Count += 1;
                    }
                    else
                    {
                        carts.Add(new Cart
                        {
                            Id = id,
                            Name = product.Name,
                            Count = 1,
                            Price = product.Price
                        });
                    }
                }
                httpContextAccessor.HttpContext.Response.Set(CookieKey.cartCookie, carts, null);
            }
            catch (System.Exception)
            {
                result = false;
            }

            return result;
        }
    }
}