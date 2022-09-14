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
        public async Task<ActionResult<ResponseDTO>> InsertPhoto(ItemPhotoInsertDTO itemPhoto)
        {
            ResponseDTO response = await services.InsertPhoto(itemPhoto);

            return StatusCode(response.status, response);
        }

        [HttpGet("{itemId:int}")]
        public async Task<ActionResult<returnItemPhotoDTO>> getAllItemPhotos(int itemId)
        {
            returnItemPhotoDTO response = await services.getAllItemPhotos(itemId);

            return StatusCode(response.status, response);
        }

        [HttpGet("{itemId:int}/{photoId:int}")]
        public async Task<ActionResult<returnItemPhotoDTO>> getItemPhotosById(int itemId, int photoId)
        {
            returnItemPhotoDTO response = await services.getItemPhotosById(itemId,photoId);

            return StatusCode(response.status, response);
        }

        [HttpDelete("{itemPhotoId:int}")]
        public async Task<ActionResult<ResponseDTO>> DeletePhoto(int itemPhotoId)
        {
            ResponseDTO response = await services.DeletePhoto(itemPhotoId);

            return StatusCode(response.status, response);
        }
    }
}
