using System;
using System.Collections.Generic;
using System.Text;

namespace Mekhnin.Shelter.Context.Shelter.Models
{
    public class VolunteerModel : BaseModel<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
    }
}
