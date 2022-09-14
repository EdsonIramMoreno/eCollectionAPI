namespace Core.DTO.Category
{
    public class returnCategoryDTO
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<ErrorDTO> errors { get; set; }
        public List<CategoryDTO> categories { get; set; }
    }
}
