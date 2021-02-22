using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Data.Shelter;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter
{
    internal abstract class BaseSoftDeleteRepository<TM, TE, TIdentity, TContext>
        : BaseIdentityRepository<TM, TE, TIdentity, TContext>
        where TM : BaseModel<TIdentity>
            where TE : SoftDeleteEntity<TIdentity>
            where TContext : DbContext
    {
        public BaseSoftDeleteRepository(
            IBaseContextFactory<TContext> contextFactory,
            IMapper<TM, TE> mapper
        )
            : base(
                contextFactory,
                mapper
                )
        {
        }

        public override async Task DeleteAsync(TIdentity id, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            if (entity != null)
            {
                entity.IsDeleted = true;

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
