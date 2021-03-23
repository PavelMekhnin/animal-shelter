using Mekhnin.Shelter.Data.Shelter;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    /// <summary>
    /// Model to identity and entity to model mapper
    /// </summary>
    /// <typeparam name="TM">Type of model</typeparam>
    /// <typeparam name="TE">Type of entity</typeparam>
    public interface IMapper<TM, in TE>
        where TM : class
        where TE : IEntity
    {
        /// <summary>
        /// Map entity to model (new instance)
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>New model</returns>
        public TM MapToModel(TE entity);

        /// <summary>
        /// Map model to entity
        /// </summary>
        /// <param name="model">Model</param>
        /// <param name="entity">Entity</param>
        public void MapToEntity(TM model, TE entity);
    }
}
