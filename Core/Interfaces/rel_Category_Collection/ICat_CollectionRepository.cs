using Core.DTO.rel_Category_Collection;

namespace Core.Interfaces.rel_Category_Collection
{
    public interface ICat_CollectionRepository
    {
        public Task insertRel(int idCollection, int idCategory);
    }
}
