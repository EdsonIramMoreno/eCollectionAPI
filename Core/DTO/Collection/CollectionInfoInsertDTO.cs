using Microsoft.AspNetCore.Http;

namespace Core.DTO.Collection
{
    public class CollectionInfoInsertDTO
    {
        public string collectionName { get; set; }
        public IFormFile collectionCover { get; set; }
        public string fk_userId { get; set; }
    }
}
