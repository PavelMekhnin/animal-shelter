using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Data.Shelter;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IIdentityRepository<TM, TE, in TIdentity> : IRepository<TM, TE>
        where TM : BaseModel<TIdentity>
        where TE : IdentityEntity<TIdentity>
    {
        public Task<TM> GetAsync(TIdentity id);
        public IAsyncEnumerable<TM> GetAsync();
        public Task<TM> SaveAsync(TM model);
        public Task DeleteAsync(TIdentity id);
    }
}
