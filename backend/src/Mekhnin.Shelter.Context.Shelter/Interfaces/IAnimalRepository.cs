using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IAnimalRepository
        : IIdentityRepository<AnimalModel, Data.Shelter.Entities.Animal, int>
    {
        Task<List<AnimalModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken);
        Task<List<AnimalModel>> GetListByVolunteerAsync(int volunteerId, CancellationToken cancellationToken);
        Task<AnimalModel> ArchiveAnimalAsync(int id, CancellationToken cancellationToken);
    }
}
