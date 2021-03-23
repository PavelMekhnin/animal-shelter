using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    /// <summary>
    /// Animal repository
    /// </summary>
    public interface IAnimalRepository
        : IIdentityRepository<AnimalModel, Data.Shelter.Entities.Animal, int>
    {
        /// <summary>
        /// Get list of animals by shelter identificator
        /// </summary>
        /// <param name="shelterId">Identificator of shelter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of animals</returns>
        Task<List<AnimalModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken);

        /// <summary>
        /// Get list of animals by volunteer identificator
        /// </summary>
        /// <param name="volunteerId">Identificator of volunteer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of animals</returns>
        Task<List<AnimalModel>> GetListByVolunteerAsync(int volunteerId, CancellationToken cancellationToken);

        /// <summary>
        /// Archive animal
        /// </summary>
        /// <param name="id">Identificator of animal</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Archived animal</returns>
        Task<AnimalModel> ArchiveAnimalAsync(int id, CancellationToken cancellationToken);
    }
}
