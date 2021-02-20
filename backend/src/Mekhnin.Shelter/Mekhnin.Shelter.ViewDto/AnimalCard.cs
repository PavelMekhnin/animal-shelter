using System;
using System.Collections.Generic;
using System.Text;

namespace Mekhnin.Shelter.ViewDto
{
    public class AnimalCard
    {
        public int Id { get; set; }
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Bio { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
        public List<Need> Needs { get; set; }
        public List<VolunteerCardPreview> Volunteers { get; set; }
    }
}
