namespace Core.DTO.Item.ItemPhoto
{
    public class returnItemPhotoDTO
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<ErrorDTO> errors { get; set; }
        public List<ItemPhotoDisplayDTO> itemPhotos { get; set; }
    }
}
