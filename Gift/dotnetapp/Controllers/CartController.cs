// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/cart")]  
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("add")]
    public IActionResult addCart([FromBody] Cart cart)
    {
        // var addedCart = _cartService.addCart(cart);
        var addedCart = _cartService.addCartWithInclude(cart);
        return Ok(addedCart);
    }

    [HttpPost("update")]
    public IActionResult updateCart([FromBody] Cart updatedCart)
    {
        var result = _cartService.updateCart(updatedCart);

        if (result != null)
        {
            return Ok(result);
        }

        return NotFound("Cart not found");
    }

    [HttpGet("getByCustomerId/{customerId}")]
    public IActionResult getCartByCustomerId(long customerId)
    {
        var cart = _cartService.getCartByCustomerId(customerId);

        if (cart != null)
        {
            return Ok(cart);
        }

        return NotFound("Cart not found");
    }

    [HttpGet("includeUserAndGifts/{customerId}")]
    public IActionResult IncludeUserAndGifts(long customerId)
    {
        var carts = _cartService.IncludeUserAndGifts(customerId);
        return Ok(carts);
    }

    [HttpPost("addWithCustomerId/{customerId}")]
    public IActionResult addCartWithCustomerId(long customerId, [FromBody] Cart cart)
    {
        var addedCart = _cartService.addCartWithCustomerId(customerId, cart);
        return Ok(addedCart);
    }
    }
}
