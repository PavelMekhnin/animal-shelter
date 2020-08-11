using System.Collections.Generic;
using System.Linq;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Context;
using Mekhnin.Shelter.Data.Shelter.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter.Repositories
{
    internal class NeedRepository
        : BaseSoftDeleteRepository<NeedModel, Data.Shelter.Entities.Need, int, ShelterContext>,
            INeedRepository
    {
        public NeedRepository(
            IBaseContextFactory<ShelterContext> contextFactory,
            IMapper<NeedModel, Need> mapper
            ) 
            : base(
                contextFactory,
                mapper
                )
        {
        }

        protected override IQueryable<Need> GetQueryable(ShelterContext context)
        {
            return context.Needs;
        }

        public async IAsyncEnumerable<NeedModel> GetListByShelterAsync(int shelterId)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.ShelterId == shelterId).ToArrayAsync();

            foreach (var entity in entities)
            {
                yield return Mapper.MapToModel(entity);
            }
        }

        public async IAsyncEnumerable<NeedModel> GetListByAnimalAsync(int animalId)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.AnimalId == animalId).ToArrayAsync();

            foreach (var entity in entities)
            {
                yield return Mapper.MapToModel(entity);
            }
        }
    }
}
