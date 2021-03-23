namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    /// <summary>
    /// Contact of a shelter
    /// </summary>
    public class Contact : SoftDeleteEntity<int>
    {
        /// <summary>
        /// Contact's volunteer id
        /// </summary>
        public int VolunteerId { get; set; }

        /// <summary>
        /// Type (e-mail, telephone, etc.)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Value (e-mail address, tel. naumber, etc.)
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Contact's volunteer
        /// </summary>
        public Volunteer Volunteer { get; set; }
    }
}
