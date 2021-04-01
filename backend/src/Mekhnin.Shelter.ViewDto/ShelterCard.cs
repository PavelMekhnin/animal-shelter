using System.Collections.Generic;

namespace Mekhnin.Shelter.ViewDto
{
    public class ShelterCard
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
        public string CoverUrl { get; set; }
        public List<VolunteerCardPreview> Volunteers { get; set; }
        public List<AnimalCard> Animals { get; set; }
        public List<Need> Needs { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
