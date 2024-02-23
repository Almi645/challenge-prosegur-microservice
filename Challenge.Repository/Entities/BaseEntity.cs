using System.ComponentModel.DataAnnotations;

namespace Challenge.Repository.Entities
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
}
