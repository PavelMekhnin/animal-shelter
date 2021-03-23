using System.Collections.Generic;

namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    /// <summary>
    /// Animal entity
    /// </summary>
    public class Animal : SoftDeleteEntity<int>
    {
        /// <summary>
        /// Pet Name (Nick Name)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pet's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Short pet's bio or history
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Race (pitbull, cogry, etc.)
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        /// Pet's age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Main image url
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// Host shelter id
        /// </summary>
        public int ShelterId { get; set; }

        /// <summary>
        /// Host shelter
        /// </summary>
        public Shelter Shelter { get; set; }

        /// <summary>
        /// Animal's needs
        /// </summary>
        public ICollection<Need> Needs { get; set; }
    }
}
