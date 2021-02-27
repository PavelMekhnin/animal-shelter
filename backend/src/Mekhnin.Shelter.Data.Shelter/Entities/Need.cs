namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    public class Need : SoftDeleteEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public bool IsDone { get; set; }
        public int ShelterId { get; set; }
        public int? AnimalId { get; set; }
        public Shelter Shelter { get; set; }
        public Animal Animal { get; set; }
    }
}
