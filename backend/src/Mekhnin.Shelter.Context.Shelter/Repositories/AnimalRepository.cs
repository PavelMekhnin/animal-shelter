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
    internal class AnimalRepository 
        : BaseSoftDeleteRepository<AnimalModel, Data.Shelter.Entities.Animal, int, ShelterContext>,
        IAnimalRepository
    {
        public AnimalRepository(
            IBaseContextFactory<ShelterContext> contextFactory,
            IMapper<AnimalModel, Animal> mapper
            ) 
            : base(
                contextFactory,
                mapper
                )
        {
        }

        public async IAsyncEnumerable<AnimalModel> GetListByShelterAsync(int shelterId)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.ShelterId == shelterId).ToArrayAsync();

            foreach (var entity in entities)
            {
                yield return Mapper.MapToModel(entity);
            }
        }

        public IAsyncEnumerable<AnimalModel> GetListByVolunteerAsync(int volunteerId)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Animal> GetQueryable(ShelterContext context)
        {
            return context.Animals;
        }
    }
}
