using System.Linq;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Context;
using Microsoft.EntityFrameworkCore;

namespace Mekhnin.Shelter.Context.Shelter.Repositories
{
    /// <summary>
    /// Shelter soft-delete repository
    /// </summary>
    internal class ShelterRepository 
        : BaseSoftDeleteRepository<ShelterModel, Data.Shelter.Entities.Shelter, int, ShelterContext>,
            IShelterRepository
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
            return context.Shelters
                .Include(x => x.Animals)
                .Include(x => x.Needs)
                .Include(x => x.ShelterVolunteers)
                .ThenInclude(x => x.Volunteer);
        }
    }
}
