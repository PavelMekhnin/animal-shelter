using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IVolunteerRepository
        : IIdentityRepository<VolunteerModel, Data.Shelter.Entities.Volunteer, int>
    {
        Task<List<VolunteerModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken);
        Task<List<VolunteerModel>> GetListByAnimalAsync(int animalId, CancellationToken cancellationToken);
    }
}
