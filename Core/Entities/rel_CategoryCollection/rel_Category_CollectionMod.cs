namespace Core.Entities.rel_CategoryCollection
{
    public class rel_Category_CollectionMod
    {
        public int id { get; set; }
        public int fk_categoryId { get; set; }
        public int fk_collectionId { get; set; }
    }
}
