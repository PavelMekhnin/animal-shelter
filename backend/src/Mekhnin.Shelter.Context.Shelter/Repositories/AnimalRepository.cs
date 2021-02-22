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

        public async Task<List<AnimalModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken)
        {
            await using var context = ContextFactory.Create();
            var entities = await GetQueryable(context)
                .Where(x => x.ShelterId == shelterId)
                .ToArrayAsync(cancellationToken);

            var result = new List<AnimalModel>();
            foreach (var entity in entities)
            {
                result.Add(Mapper.MapToModel(entity));
            }

            return result;
        }

        public Task<List<AnimalModel>> GetListByVolunteerAsync(int volunteerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalModel> ArchiveAnimalAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Animal> GetQueryable(ShelterContext context)
        {
            return context.Animals;
        }
    }
}
