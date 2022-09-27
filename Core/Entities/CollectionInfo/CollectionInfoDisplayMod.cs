namespace Core.Entities.CollectionInfo
{
    public class CollectionInfoDisplayMod
    {
        public int collectionId { get; set; }
        public string collectionName { get; set; }
        public string collectionCover { get; set; }
        public string categories { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
        public int itemNumberCollection { get; set; }
        public string fk_userId { get; set; }
    }
}
