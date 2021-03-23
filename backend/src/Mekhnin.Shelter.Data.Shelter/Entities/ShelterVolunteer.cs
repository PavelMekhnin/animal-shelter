namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    /// <summary>
    /// Volunteer to Shelter many-to-many entity
    /// </summary>
    public class ShelterVolunteer : IEntity
    {
        /// <summary>
        /// Shelter id
        /// </summary>
        public int ShelterId { get; set; }
        /// <summary>
        /// Volunteer id
        /// </summary>
        public int VolunteerId { get; set; }

        /// <summary>
        /// Is the volunteer is main at the shelter
        /// </summary>
        public bool IsMain { get; set; }

        /// <summary>
        /// Rank of the volunteer at the shelter
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Shelter
        /// </summary>
        public Shelter Shelter { get; set; }

        /// <summary>
        /// Volunteer
        /// </summary>
        public Volunteer Volunteer { get; set; }
    }
}
