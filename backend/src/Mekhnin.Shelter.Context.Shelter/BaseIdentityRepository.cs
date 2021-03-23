using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Data.Shelter;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter
{
    /// <summary>
    /// Base repository for entity with identity field
    /// </summary>
    /// <typeparam name="TM">Type of model</typeparam>
    /// <typeparam name="TE">Type of entity</typeparam>
    /// <typeparam name="TIdentity">Type of identity field</typeparam>
    /// <typeparam name="TContext">Type of context</typeparam>
    internal abstract class BaseIdentityRepository<TM, TE, TIdentity, TContext>
        : BaseRepository<TM, TE, TContext>,
        IIdentityRepository<TM, TE, TIdentity>
        where TM : BaseModel<TIdentity>
        where TE : IdentityEntity<TIdentity>
        where TContext : DbContext
    {

        public BaseIdentityRepository(
            IBaseContextFactory<TContext> contextFactory,
            IMapper<TM, TE> mapper
            )
        : base(
            contextFactory,
            mapper
            )
        {
        }

        public async Task<TM> GetAsync(TIdentity id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<ICollection<TM>> GetAsync(CancellationToken cancellationToken)
        {
            return await base.GetListAsync(cancellationToken);
        }

        public async Task<TM> SaveAsync(TM model, CancellationToken cancellationToken)
        {
            return await base.SaveAsync(model, x => x.Id.Equals(model.Id), cancellationToken);
        }

        public virtual async Task DeleteAsync(TIdentity id, CancellationToken cancellationToken)
        {
            await base.DeleteAsync(x => x.Id.Equals(id), cancellationToken);
        }
    }
}
