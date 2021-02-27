namespace Mekhnin.Shelter.Context.Shelter.Models
{
    public class ShelterModel : BaseModel<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoUrl { get; set; }
        public string CoverUrl { get; set; }
    }
}
