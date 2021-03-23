using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    /// <summary>
    /// Volunteer repository
    /// </summary>
    public interface IVolunteerRepository
        : IIdentityRepository<VolunteerModel, Data.Shelter.Entities.Volunteer, int>
    {

        /// <summary>
        /// Get list of volunteers by shelter identificator
        /// </summary>
        /// <param name="shelterId">Identificator of shelter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of volunteers</returns>
        Task<List<VolunteerModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken);

        /// <summary>
        /// Get list of volunteers by animal identificator
        /// </summary>
        /// <param name="animalId">Identificator of animal</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of volunteers</returns>
        Task<List<VolunteerModel>> GetListByAnimalAsync(int animalId, CancellationToken cancellationToken);
    }
}
