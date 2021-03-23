namespace Mekhnin.Shelter.Data.Shelter
{
    /// <summary>
    /// Base class for entity with soft delete option
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    public abstract class SoftDeleteEntity<TEntity> : IdentityEntity<TEntity>
    {
        /// <summary>
        /// Soft delete field of entity
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
