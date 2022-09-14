using System.Data.SqlTypes;

namespace Core.Entities.Item.ItemInfo
{
    public class ItemInfoMod
    {
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public SqlMoney marketPrice { get; set; }
        public SqlMoney acquiredPrice { get; set; }
        public string itemCover { get; set; }
        public DateOnly creationDate { get; set; }
        public DateTime lastUpdateDate { get; set; }
        public int fk_collectionId { get; set; }
    }
}
