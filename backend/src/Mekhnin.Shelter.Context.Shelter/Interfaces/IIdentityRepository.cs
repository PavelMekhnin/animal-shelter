using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Data.Shelter;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    /// <summary>
    /// Base repository for entity with identity field
    /// </summary>
    /// <typeparam name="TM">Type of model</typeparam>
    /// <typeparam name="TE">Type of entity</typeparam>
    /// <typeparam name="TIdentity">Type of identity field</typeparam>
    public interface IIdentityRepository<TM, TE, in TIdentity> : IRepository<TM, TE>
        where TM : BaseModel<TIdentity>
        where TE : IdentityEntity<TIdentity>
    {
        /// <summary>
        /// Get model by identity field
        /// </summary>
        /// <param name="id">Identificator of model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Model</returns>
        public Task<TM> GetAsync(TIdentity id, CancellationToken cancellationToken);

        /// <summary>
        /// Get firts of default model by predicate
        /// </summary>
        /// <param name="predicate">Predicate for filtering</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Model</returns>
        public Task<ICollection<TM>> GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Save model by identity field "id"
        /// </summary>
        /// <param name="model">Model to save</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Saved model</returns>
        public Task<TM> SaveAsync(TM model, CancellationToken cancellationToken);

        /// <summary>
        /// Delete entity by identity field
        /// </summary>
        /// <param name="id">Identificator of model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public Task DeleteAsync(TIdentity id, CancellationToken cancellationToken);
    }
}
