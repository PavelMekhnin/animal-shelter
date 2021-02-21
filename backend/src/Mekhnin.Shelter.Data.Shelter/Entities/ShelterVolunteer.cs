namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    public class ShelterVolunteer : IEntity
    {
        public int ShelterId { get; set; }
        public int VolunteerId { get; set; }
        public bool IsMain { get; set; }
        public int Rank { get; set; }
        public Shelter Shelter { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
