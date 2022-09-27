namespace Core.DTO.Collection
{
    public class CollectionInfoDisplayDTO
    {
        public int collectionId { get; set; }
        public string collectionName { get; set; }
        public string collectionCover { get; set; }
        public string categories { get; set; }
        public string creationDate { get; set; }
        public string lastUpdateDate { get; set; }
        public int itemNumberCollection { get; set; }
        public string fk_userId { get; set; }
    }
}
