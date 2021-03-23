using System.Collections.Generic;

namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    /// <summary>
    /// Animal shelter entity
    /// </summary>
    public class Shelter : SoftDeleteEntity<int>
    {
        /// <summary>
        /// Main title of a Shelter
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Main description of a shelter
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Address of a shelter
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Url of the main logo
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Url of shelter page's head cover
        /// </summary>
        public string CoverUrl { get; set; }

        /// <summary>
        /// All animalas of a shelter
        /// </summary>
        public ICollection<Animal> Animals { get; set; }

        /// <summary>
        /// All need of a shelter
        /// </summary>
        public ICollection<Need> Needs { get; set; }

        /// <summary>
        /// All volunteers of a shelter
        /// </summary>
        public ICollection<ShelterVolunteer> ShelterVolunteers { get; set; }
    }
}
