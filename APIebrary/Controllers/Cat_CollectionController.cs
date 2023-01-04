using Core.DTO;
using Core.DTO.rel_Category_Collection;
using Core.Interfaces.rel_Category_Collection;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/cat_collection")] //https://localhost:7001/api/cat_collection/
    [ApiController]
    public class Cat_CollectionController : ControllerBase
    {
        private readonly ICat_CollectionServices services;

        public Cat_CollectionController(ICat_CollectionServices services)
        {
            this.services = services;
        }

        [HttpPost("insert")]
        public async Task<ActionResult> InsertRel(rel_Cat_Collection_DTO rel_Cat)
        {
            ResponseDTO response = await services.insertRel(rel_Cat);

            return StatusCode(response.status);
        }
    }
}
