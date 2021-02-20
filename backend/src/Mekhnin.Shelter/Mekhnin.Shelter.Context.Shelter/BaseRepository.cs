using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Data.Shelter;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter
{
    public abstract class BaseRepository<TM, TE, TContext> : IRepository<TM, TE>
        where TM : class
        where TE : IEntity
        where TContext : DbContext
    {

        protected IBaseContextFactory<TContext> ContextFactory { get; }
        protected IMapper<TM, TE> Mapper { get; }

        public BaseRepository(
            IBaseContextFactory<TContext> contextFactory,
            IMapper<TM, TE> mapper
        )
        {
            ContextFactory = contextFactory;
            Mapper = mapper;
        }

        protected async Task<TM> GetAsync(Expression<Func<TE, bool>> predicate)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                return default(TM);
            }

            return Mapper.MapToModel(entity);
        }
        
        protected async IAsyncEnumerable<TM> GetListAsync(Expression<Func<TE, bool>> predicate)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(predicate).ToArrayAsync();
            
            foreach (var entity in entities)
            {
                yield return Mapper.MapToModel(entity);
            }
        }

        public async Task<TM> SaveAsync(TM model, Expression<Func<TE, bool>> predicate)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(predicate);

            if (entity == null)
            {
                entity = Activator.CreateInstance<TE>();
                await context.AddAsync(entity);
            }

            Mapper.MapToEntity(model, entity);

            await context.SaveChangesAsync();

            return Mapper.MapToModel(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<TE, bool>> predicate)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(predicate);

            if (entity != null)
            {
                context.Remove(entity);

                await context.SaveChangesAsync();
            }
        }

        protected abstract IQueryable<TE> GetQueryable(TContext context);
    }
}
