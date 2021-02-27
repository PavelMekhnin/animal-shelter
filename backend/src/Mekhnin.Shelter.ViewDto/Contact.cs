using System;
using System.Collections.Generic;
using System.Text;

namespace Mekhnin.Shelter.ViewDto
{
    public class Contact
    {
        public int Id { get; set; }
        public int VolunteerId { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
        public string Owner { get; set; }
    }
}
