using System.Collections.Generic;

namespace Challenge.Repository.Entities
{
    public class Menu : BaseEntity
    {
        public string name { get; set; }
        public string url { get; set; }
        public List<Action> actions { get; set; }
    }
}
