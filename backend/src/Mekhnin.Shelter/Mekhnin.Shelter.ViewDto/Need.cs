using System;
using System.Collections.Generic;
using System.Text;

namespace Mekhnin.Shelter.ViewDto
{
    public class Need
    {
        public int Id { get; set; }
        public int ShelterId { get; set; }
        public int? AnimalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public bool IsDone { get; set; }
    }
}
