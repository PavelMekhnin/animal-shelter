using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface INeedRepository
        : IIdentityRepository<NeedModel, Data.Shelter.Entities.Need, int>
    {
        Task<List<NeedModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken);
        Task<List<NeedModel>> GetListByAnimalAsync(int animalId, CancellationToken cancellationToken);
    }
}
