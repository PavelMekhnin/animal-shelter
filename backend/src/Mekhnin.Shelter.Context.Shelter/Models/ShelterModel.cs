using System.Collections.Generic;

namespace Mekhnin.Shelter.Context.Shelter.Models
{
    public class ShelterModel : BaseModel<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
        public string CoverUrl { get; set; }

        public List<AnimalModel> Animals { get; set; }
        public List<NeedModel> Needs { get; set; }
        public List<VolunteerModel> Volunteers { get; set; }
        public List<ContactModel> Contacts { get; set; }
    }
}
