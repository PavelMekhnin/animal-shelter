using System.Collections.Generic;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IVolunteerRepository
        : IIdentityRepository<VolunteerModel, Data.Shelter.Entities.Volunteer, int>
    {
        IAsyncEnumerable<VolunteerModel> GetListByShelterAsync(int shelterId);
        IAsyncEnumerable<VolunteerModel> GetListByAnimalAsync(int animalId);
    }
}
