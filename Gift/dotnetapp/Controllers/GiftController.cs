// Controllers/GiftController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/gift")]  // Assuming you want the endpoint to be "api/gift"
    public class GiftController : ControllerBase
    {
        private readonly GiftService _giftService;

        public GiftController(GiftService giftService)
        {
            _giftService = giftService;
        }

        [HttpPost]
        public IActionResult addGift([FromBody] Gift gift)
        {
            var addedGift = _giftService.AddGift(gift);

            return CreatedAtAction(nameof(viewAllGifts), new { id = addedGift.GiftId }, addedGift);
        }

        [HttpGet]
        public IActionResult viewAllGifts()
        {
            var gifts = _giftService.GetAllGifts();

            return Ok(gifts);
        }

        [HttpPut("{id}")]
        public IActionResult updateGift(long id, [FromBody] Gift updatedGift)
        {
            var editedGift = _giftService.EditGift(id, updatedGift);

            if (editedGift != null)
            {
                return Ok(editedGift);
            }

            return NotFound(new { Message = "Gift not found." });
        }

        [HttpDelete("{id}")]
        public IActionResult deleteGift(long id)
        {
            var deletedGift = _giftService.DeleteGift(id);

            if (deletedGift != null)
            {
                return Ok(deletedGift);
            }

            return NotFound(new { Message = "Gift not found." });
        }
    }
}