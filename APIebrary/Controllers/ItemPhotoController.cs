using Core.DTO.Item.ItemInfo;
using Core.DTO;
using Core.Interfaces.Item.ItemPhoto;
using Microsoft.AspNetCore.Mvc;
using Core.DTO.Item.ItemPhoto;
using Core.DTO.Category;
using Core.DTO.User;

namespace API.Controllers
{
    [Route("api/itemphoto")] //https://localhost:7001/api/item
    [ApiController]
    public class ItemPhotoController : ControllerBase
    {
        private readonly IItemPhotoServices services;

        public ItemPhotoController(IItemPhotoServices services)
        {
            this.services = services;
        }


        [HttpPost("insert")]
        public async Task<ActionResult> InsertPhoto(ItemPhotoInsertDTO itemPhoto)
        {
            var response = await services.InsertPhoto(itemPhoto);

            return StatusCode(response, response);
        }

        [HttpGet("{itemId:int}/{photoId:int}")]
        public async Task<ActionResult> getItemPhotosById(int itemId, int photoId)
        {
            var response = await services.getItemPhotosById(itemId,photoId);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The category catalog was not found."
                });
            }

            return StatusCode(200, response);
        }

        [HttpPost("{itemPhotoId:int}")]
        public async Task<ActionResult<ResponseDTO>> DeletePhoto(int itemPhotoId)
        {
            ResponseDTO response = await services.DeletePhoto(itemPhotoId);

            return StatusCode(response.status, response);
        }
    }
}
