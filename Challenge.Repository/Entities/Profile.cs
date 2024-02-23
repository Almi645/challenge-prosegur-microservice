using System.Collections.Generic;

namespace Challenge.Repository.Entities
{
    public class Profile : BaseEntity
    {
        public string name { get; set; }
        public List<ProfileAction> profileActions { get; set; }
    }
}
