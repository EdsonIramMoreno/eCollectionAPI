using Core.DTO;
using Core.DTO.Collection;
using Core.Interfaces.Collection;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace API.Controllers
{
    [Route("api/collection")] //https://localhost:7001/api/collection
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionServices services;

        public CollectionController(ICollectionServices services)
        {
            this.services = services;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ResponseDTO>> CreateCollection(CollectionInfoInsertDTO collectionInfo)
        {
            ResponseDTO response = await services.CreateCollection(collectionInfo);

            return StatusCode(response.status, response);
        }

        [HttpGet("userCollections/{fk_userId}")]
        public async Task<ActionResult> getCollectionInfoDisplay(string fk_userId)
        {
            var response = await services.getCollectionInfoDisplay(fk_userId);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "Collections of the user: " + fk_userId + " were not found."
                }); ;
            }

            return StatusCode(200, response);
        }

        [HttpGet("collectionById/{collectionId:int}")]
        public async Task<ActionResult> getCollectionById(int collectionId)
        {
            var response = await services.getCollectionById(collectionId);

            if (response == null)
            {
                return StatusCode(404, new ErrorDTO
                {
                    message = "Collection with id: " + collectionId + " was not found."
                }); ;
            }

            return StatusCode(200, response);
        }

        [HttpPut("update")]
        public async Task<ActionResult> CollectionInfoUpdate(CollectionInfoUpdateDTO collection)
        {
            ResponseDTO response = await services.CollectionInfoUpdate(collection);

            return StatusCode(response.status, response);
        }

        [HttpDelete("delete/{collectionId:int}")]
        public async Task<ActionResult> DeleteCollection(int collectionId)
        {
            ResponseDTO response = await services.DeleteCollection(collectionId);

            return StatusCode(response.status, response);
        }
    }
}
