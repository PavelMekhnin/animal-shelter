namespace Mekhnin.Shelter.Data.Shelter
{
    public abstract class SoftDeleteEntity<TEntity> : IdentityEntity<TEntity>
    {
        public bool IsDeleted { get; set; }
    }
}
