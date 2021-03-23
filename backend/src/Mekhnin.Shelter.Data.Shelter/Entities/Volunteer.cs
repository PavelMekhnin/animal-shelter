using System.Collections.Generic;

namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    /// <summary>
    /// Volunteer entity
    /// </summary>
    public class Volunteer : SoftDeleteEntity<int>
    {
        /// <summary>
        /// First name of the volunteer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the volunteer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Url of the main volunteer's image
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// All shelters of the volunteer
        /// </summary>
        public ICollection<ShelterVolunteer> ShelterVolunteers { get; set; }

        /// <summary>
        /// All contacts of the volunteer
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }
    }
}
