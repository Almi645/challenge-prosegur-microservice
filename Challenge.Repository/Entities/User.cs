namespace Challenge.Repository.Entities
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public int profileId { get; set; }
    }
}
