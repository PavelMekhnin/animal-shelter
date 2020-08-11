namespace Mekhnin.Shelter.Context.Shelter.Models
{
    public class AnimalModel : BaseModel<int>
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
    }
}
