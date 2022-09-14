using System.Data.SqlTypes;

namespace Core.Entities.CollectionInfo
{
    public class CollectionInfoMod
    {
        public int collectionId { get; set; }
        public string collectionName { get; set; }
        public string collectionCover { get; set; }
        public SqlMoney totalPrice { get; set; }
        public DateOnly creationDate { get; set; }
        public DateOnly lastUpdateDate { get; set; }
        public string fk_userId { get; set; }
    }
}
