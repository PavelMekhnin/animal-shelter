using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Services
{
    internal class ShelterService : IShelterService
    {
        private readonly IShelterRepository _shelterRepository;

        public ShelterService(
            IShelterRepository shelterRepository
            )
        {
            _shelterRepository = shelterRepository;
        }

        public async Task<ShelterModel> GetShelterAsync(int id, CancellationToken cancellationToken)
        {
            return await _shelterRepository.GetAsync(id, cancellationToken);
        }

        public async Task<ICollection<ShelterModel>> GetSheltersAsync(ShelterSearchParameters parameters, CancellationToken cancellationToken)
        {
            return await _shelterRepository.GetAsync(cancellationToken);
        }

        public async Task<ShelterModel> SaveShelterAsync(ShelterModel model, CancellationToken cancellationToken)
        {
            return await _shelterRepository.SaveAsync(model, cancellationToken);
        }

        public async Task DeleteShelterAsync(int id, CancellationToken cancellationToken)
        {
            await _shelterRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
