using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    /// <summary>
    /// Need repository
    /// </summary>
    public interface INeedRepository
        : IIdentityRepository<NeedModel, Data.Shelter.Entities.Need, int>
    {
        /// <summary>
        /// Get list of needs by shelter identificator
        /// </summary>
        /// <param name="shelterId">Identificator of shelter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of needs</returns>
        Task<List<NeedModel>> GetListByShelterAsync(int shelterId, CancellationToken cancellationToken);

        /// <summary>
        /// Get list of needs by animal identificator
        /// </summary>
        /// <param name="animalId">Identificator of animal</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of needs</returns>
        Task<List<NeedModel>> GetListByAnimalAsync(int animalId, CancellationToken cancellationToken);
    }
}
