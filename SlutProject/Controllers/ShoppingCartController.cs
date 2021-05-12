using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SlutProject.Models;

namespace SlutProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IDiamondRepository _piRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly LinkGenerator _linkGenerator;

        public ShoppingCartController(IDiamondRepository piRepository, ShoppingCart shoppingCart, LinkGenerator linkGenerator)
        {
            _piRepository = piRepository;
            _shoppingCart = shoppingCart;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartItem>>> Get()
        {
            return await _shoppingCart.GetShoppingCartItems().ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(int diamondId)
        {
            var selectedDiamond = _piRepository.AllDiamonds.FirstOrDefault(p => p.DiamondId == diamondId);

            if (await _shoppingCart.AddToCart(selectedDiamond, 1)) return Ok();

            return BadRequest("Failed to add item");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int diamondId)
        {
            var selectedDiamond = _piRepository.AllDiamonds.FirstOrDefault(p => p.DiamondId == diamondId);

            if (await _shoppingCart.RemoveFromCart(selectedDiamond)) return Ok();

            return BadRequest("Failed to delete item");
        }
    }
}
