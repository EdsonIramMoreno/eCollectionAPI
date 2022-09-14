using Core.DTO;
using Core.DTO.rel_Category_Collection;

namespace Core.Interfaces.rel_Category_Collection
{
    public interface ICat_CollectionServices
    {
        public Task<ResponseDTO> insertRel(rel_Cat_Collection_DTO rel_Cat);
    }
}
