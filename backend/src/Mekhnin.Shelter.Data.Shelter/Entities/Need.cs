namespace Mekhnin.Shelter.Data.Shelter.Entities
{
    /// <summary>
    /// Animal's or shelter's need
    /// </summary>
    public class Need : SoftDeleteEntity<int>
    {
        /// <summary>
        /// Short title of a need
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of a need
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Required quantity of a need
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Status of the need's completeness
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Shelter id
        /// </summary>
        public int ShelterId { get; set; }

        /// <summary>
        /// Animal id (optional)
        /// </summary>
        public int? AnimalId { get; set; }

        /// <summary>
        /// Shelter of a need
        /// </summary>
        public Shelter Shelter { get; set; }

        /// <summary>
        /// Animal of a need
        /// </summary>
        public Animal Animal { get; set; }
    }
}
