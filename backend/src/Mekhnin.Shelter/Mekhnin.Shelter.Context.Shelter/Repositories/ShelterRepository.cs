using System.Linq;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Context;

namespace Mekhnin.Shelter.Context.Shelter.Repositories
{
    internal class ShelterRepository 
        : BaseSoftDeleteRepository<ShelterModel, Data.Shelter.Entities.Shelter, int, ShelterContext>, IShelterRepository
    {
        public ShelterRepository(
            IBaseContextFactory<ShelterContext> contextFactory,
            IMapper<ShelterModel, Data.Shelter.Entities.Shelter> mapper
            ) 
            : base(contextFactory, mapper)
        {
        }

        protected override IQueryable<Data.Shelter.Entities.Shelter> GetQueryable(ShelterContext context)
        {
            return context.Shelters;
        }
    }
}
