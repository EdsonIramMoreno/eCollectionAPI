using Core.DTO;
using Core.DTO.Collection;
using Core.Interfaces.Collection;
using Microsoft.AspNetCore.Mvc;

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
    }
}
