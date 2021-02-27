using System.Collections.Generic;

namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    public class Shelter : SoftDeleteEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
        public string CoverUrl { get; set; }

        public ICollection<Animal> Animals { get; set; }
        public ICollection<Need> Needs { get; set; }
        public ICollection<ShelterVolunteer> ShelterVolunteers { get; set; }
    }
}
