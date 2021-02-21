using System.Collections.Generic;

namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    public class Volunteer : SoftDeleteEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<ShelterVolunteer> ShelterVolunteers { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
