using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Data.Shelter;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter
{
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
        : base(contextFactory, mapper)
        {
        }

        public async Task<TM> GetAsync(TIdentity id)
        {
            return await base.GetAsync(x => x.Id.Equals(id));
        }

        public IAsyncEnumerable<TM> GetAsync()
        {
            return base.GetListAsync(x => true);
        }

        public async Task<TM> SaveAsync(TM model)
        {
            return await base.SaveAsync(model, x => x.Id.Equals(model.Id));
        }

        public virtual async Task DeleteAsync(TIdentity id)
        {
            await base.DeleteAsync(x => x.Id.Equals(id));
        }
    }
}
