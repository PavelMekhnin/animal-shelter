using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<ShelterModel> GetShelterAsync(int id)
        {
            return await _shelterRepository.GetAsync(id);
        }

        public Task<ICollection<ShelterModel>> GetSheltersAsync(ShelterSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ShelterModel> SaveShelterAsync(ShelterModel model)
        {
            return await _shelterRepository.SaveAsync(model);
        }

        public async Task DeleteShelterAsync(int id)
        {
            await _shelterRepository.DeleteAsync(id);
        }
    }
}
