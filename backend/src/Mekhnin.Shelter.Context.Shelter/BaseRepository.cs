using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Data.Shelter;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter
{
    /// <summary>
    /// Base class for repositories
    /// </summary>
    /// <typeparam name="TM">Type of model</typeparam>
    /// <typeparam name="TE">Type of entity</typeparam>
    /// <typeparam name="TContext">Type of context</typeparam>
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

        protected async Task<TM> GetAsync(Expression<Func<TE, bool>> predicate, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(predicate, cancellationToken);

            if (entity == null)
            {
                return default(TM);
            }

            return Mapper.MapToModel(entity);
        }

        /// <summary>
        /// Get list of models by predicate
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="predicate">Predicate of filtering (optional)</param>
        /// <returns>List of models</returns>
        protected async Task<ICollection<TM>> GetListAsync(CancellationToken cancellationToken, Expression<Func<TE, bool>> predicate = null)
        {
            await using var context = ContextFactory.Create();
            var query = GetQueryable(context);
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var entities = await query.ToArrayAsync(cancellationToken);

            var result = new List<TM>();
            foreach (var entity in entities)
            {
                result.Add(Mapper.MapToModel(entity));
            }

            return result;
        }

        /// <summary>
        /// Save a model by predicate
        /// </summary>
        /// <param name="model">Model to save</param>
        /// <param name="predicate">Predicate of filtering</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Saved model with id</returns>
        public async Task<TM> SaveAsync(TM model, Expression<Func<TE, bool>> predicate, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(predicate, cancellationToken);

            if (entity == null)
            {
                entity = Activator.CreateInstance<TE>();
                await context.AddAsync(entity);
            }

            Mapper.MapToEntity(model, entity);

            await context.SaveChangesAsync(cancellationToken);

            return Mapper.MapToModel(entity);
        }

        /// <summary>
        /// Delete entity by predicate
        /// </summary>
        /// <param name="predicate">Predicate of filtering</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public virtual async Task DeleteAsync(Expression<Func<TE, bool>> predicate, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entity = await GetQueryable(context)
                .FirstOrDefaultAsync(predicate, cancellationToken);

            if (entity != null)
            {
                context.Remove(entity);

                await context.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Get a reference to an entity in a context
        /// </summary>
        /// <param name="context">Database context</param>
        /// <returns>Reference to an entity</returns>
        protected abstract IQueryable<TE> GetQueryable(TContext context);
    }
}
