using API.Application;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Core.DTO.Item.ItemInfo;
using Core.Interfaces.Item.ItemInfo;
using Core.DTO.Category;

namespace API.Controllers
{
    [Route("api/item")] //https://localhost:7001/api/item
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemServices services;

        public ItemController(IItemServices services)
        {
            this.services = services;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseDTO>> CreateItem(itemInsertInfoDTO itemInsertInfo)
        {
            ResponseDTO response = await services.CreateItem(itemInsertInfo);

            return StatusCode(response.status, response);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ResponseDTO>> UpdateItem(itemUpdateInfoDTO itemtInfo)
        {
            ResponseDTO response = await services.UpdateItem(itemtInfo);

            return StatusCode(response.status, response);
        }

        
        [HttpGet("{collectionId:int}")]
        public async Task<ActionResult> getAllItemsByCollectionId(int collectionId)
        {
            var response = await services.getAllItemsByCollectionId(collectionId);
            
            if (response == null || response.Count < 1)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The items in the collection: " + collectionId.ToString() + " were not found"
                });
            }

            return StatusCode(200, response);
        }

        [HttpGet("{collectionId:int}/{itemId:int}")]
        public async Task<ActionResult> getAllItemsByCollectionId(int collectionId, int itemId)
        {
            var response = await services.getItemById(collectionId, itemId);
            
            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "The items with th id: " + itemId.ToString() + " was not found"
                });
            }

            return StatusCode(200, response);
        }

        [HttpDelete("delete/{itemId:int}")]
        public async Task<ActionResult<ResponseDTO>> DeletePhoto(int itemId)
        {
            ResponseDTO response = await services.DeleteItem(itemId);

            return StatusCode(response.status, response);
        }
    }
}
