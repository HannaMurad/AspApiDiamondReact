using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProject.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public IQueryable<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            //string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //session.SetString("CartId", cartId);
            //return new ShoppingCart(context) { ShoppingCartId = cartId };
            return new ShoppingCart(context);
        }

        public async Task<bool> AddToCart(Diamond diamond, int amount)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Diamond.DiamondId == diamond.DiamondId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Diamond = diamond,
                    Amount = 1
                };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            return (await _appDbContext.SaveChangesAsync()) > 0;

        }

        public async Task<bool> RemoveFromCart(Diamond diamond)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Diamond.DiamondId == diamond.DiamondId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        public IQueryable<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(s => s.Diamond));
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(s => s.Diamond.Price * s.Amount).Sum();
            return total;
        }
            
    }
}
