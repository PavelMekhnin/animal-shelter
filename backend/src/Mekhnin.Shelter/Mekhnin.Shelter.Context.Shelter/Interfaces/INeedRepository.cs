using System.Collections.Generic;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface INeedRepository
        : IIdentityRepository<NeedModel, Data.Shelter.Entities.Need, int>
    {
        IAsyncEnumerable<NeedModel> GetListByShelterAsync(int shelterId);
        IAsyncEnumerable<NeedModel> GetListByAnimalAsync(int animalId);
    }
}
