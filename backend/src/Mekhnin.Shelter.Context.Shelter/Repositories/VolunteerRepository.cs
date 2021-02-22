using System;
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
    internal class VolunteerRepository 
        : BaseSoftDeleteRepository<VolunteerModel, Data.Shelter.Entities.Volunteer, int, ShelterContext>,
        IVolunteerRepository
    {
        public VolunteerRepository(
            IBaseContextFactory<ShelterContext> contextFactory,
            IMapper<VolunteerModel, Volunteer> mapper
            ) 
            : base(
                contextFactory,
                mapper
                )
        {
        }
        
        protected override IQueryable<Volunteer> GetQueryable(ShelterContext context)
        {
            return context.Volunteers;
        }

        public async Task<List<VolunteerModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.ShelterVolunteers.Any(v => v.ShelterId == shelterId))
                .ToArrayAsync(cancellationToken);

            var result = new List<VolunteerModel>();
            foreach (var entity in entities)
            {
                result.Add(Mapper.MapToModel(entity));
            }

            return result;
        }

        public Task<List<VolunteerModel>> GetListByAnimalAsync(int animalId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
