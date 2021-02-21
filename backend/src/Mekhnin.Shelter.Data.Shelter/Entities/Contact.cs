namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    public class Contact : SoftDeleteEntity<int>
    {
        public int VolunteerId { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }

        public Volunteer Volunteer { get; set; }
    }
}
