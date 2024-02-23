namespace Challenge.Repository.Entities
{
    public class Product : BaseEntity
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }
}
