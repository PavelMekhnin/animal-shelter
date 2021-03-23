using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<List<NeedModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.ShelterId == shelterId)
                .ToArrayAsync(cancellationToken);

            var result = new List<NeedModel>();
            foreach (var entity in entities)
            {
                result.Add(Mapper.MapToModel(entity));
            }

            return result;
        }

        public async Task<List<NeedModel>> GetListByAnimalAsync(int animalId, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.AnimalId == animalId).ToArrayAsync(cancellationToken);

            var result = new List<NeedModel>();
            foreach (var entity in entities)
            {
                result.Add(Mapper.MapToModel(entity));
            }

            return result;
        }
    }
}
