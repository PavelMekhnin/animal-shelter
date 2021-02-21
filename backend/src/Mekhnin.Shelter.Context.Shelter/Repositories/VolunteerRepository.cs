using System;
using System.Collections.Generic;
using System.Linq;
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

        public async IAsyncEnumerable<VolunteerModel> GetListByShelterAsync(int shelterId)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.ShelterVolunteers.Any(v => v.ShelterId == shelterId)).ToArrayAsync();

            foreach (var entity in entities)
            {
                yield return Mapper.MapToModel(entity);
            }
        }

        public IAsyncEnumerable<VolunteerModel> GetListByAnimalAsync(int animalId)
        {
            throw new NotImplementedException();
        }
    }
}
