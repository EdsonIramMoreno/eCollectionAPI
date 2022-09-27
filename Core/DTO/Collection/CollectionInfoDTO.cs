using System.Data.SqlTypes;

namespace Core.DTO.Collection
{
    public class CollectionInfoDTO
    {
        public int collectionId { get; set; }
        public string collectionName { get; set; }
        public string collectionCover { get; set; }
        public float totalPrice { get; set; }
        public string creationDate { get; set; }
        public string lastUpdateDate { get; set; }
        public string fk_userId { get; set; }
    }
}
