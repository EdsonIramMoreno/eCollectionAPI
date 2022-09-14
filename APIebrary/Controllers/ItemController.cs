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
        public async Task<ActionResult<returnItemInfoDisplayDTO>> getAllItemsByCollectionId(int collectionId)
        {
            returnItemInfoDisplayDTO response = await services.getAllItemsByCollectionId(collectionId);

            return StatusCode(response.status, response);
        }

        [HttpGet("{collectionId:int}/{itemId:int}")]
        public async Task<ActionResult<returnItemCompleteInfoDTO>> getAllItemsByCollectionId(int collectionId, int itemId)
        {
            returnItemCompleteInfoDTO response = await services.getItemById(collectionId, itemId);

            return StatusCode(response.status, response);
        }
    }
}
