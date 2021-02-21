using System;
using System.Collections.Generic;
using System.Text;

namespace Mekhnin.Shelter.Context.Shelter.Models
{
    public class ContactModel : BaseModel<int>
    {
        public int VolunteerId { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
    }
}
