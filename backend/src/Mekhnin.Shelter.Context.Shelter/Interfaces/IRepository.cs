using Mekhnin.Shelter.Data.Shelter;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    /// <summary>
    /// Interface-marker for repository
    /// </summary>
    /// <typeparam name="TM">Type of model</typeparam>
    /// <typeparam name="TE">Type of entity</typeparam>
    public interface IRepository<TM, TE>
        where TM : class
        where TE : IEntity
    {
    }
}
