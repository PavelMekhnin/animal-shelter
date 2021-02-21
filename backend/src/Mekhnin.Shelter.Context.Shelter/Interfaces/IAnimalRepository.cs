using System.Collections.Generic;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IAnimalRepository
        : IIdentityRepository<AnimalModel, Data.Shelter.Entities.Animal, int>
    {
        IAsyncEnumerable<AnimalModel> GetListByShelterAsync(int shelterId);
        IAsyncEnumerable<AnimalModel> GetListByVolunteerAsync(int volunteerId);
    }
}
