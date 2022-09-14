namespace Core.Entities.User
{
    public class UserInfoMod
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
        public string userEmail { get; set; }
        public string userPhoto { get; set; }
        public int fk_loginTypeId { get; set; }
    }
}
