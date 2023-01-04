namespace Core.DTO.Item.ItemInfo
{
    public class itemDisplayInfoDTO
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemCover { get; set; }
        public string lastUpdateDate { get; set; }
        public int fk_collectionId { get; set; }
    }
}
