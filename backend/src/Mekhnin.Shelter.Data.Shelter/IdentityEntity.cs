namespace Mekhnin.Shelter.Data.Shelter
{
    public abstract class IdentityEntity<T> : IEntity
    {
        public T Id { get; set; }
    }
}
