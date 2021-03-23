namespace Mekhnin.Shelter.Data.Shelter
{
    /// <summary>
    /// Base class for entity with identificator field "Id"
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public abstract class IdentityEntity<T> : IEntity
    {
        /// <summary>
        /// Identificator field of entity
        /// </summary>
        public T Id { get; set; }
    }
}
