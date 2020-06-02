using System.Collections.Generic;

namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    public class Animal : SoftDeleteEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
        public int ShelterId { get; set; }
        public Shelter Shelter { get; set; }
        public ICollection<Need> Needs { get; set; }
    }
}
