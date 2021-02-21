using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IShelterRepository 
        : IIdentityRepository<ShelterModel, Data.Shelter.Entities.Shelter, int>
    {
    }
}
