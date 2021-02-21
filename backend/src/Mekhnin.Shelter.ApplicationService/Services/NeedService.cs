using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Services
{
    internal class NeedService : INeedService
    {
        private readonly INeedRepository _needRepository;

        public NeedService(
            INeedRepository needRepository
            )
        {
            _needRepository = needRepository;
        }

        public async Task<NeedModel> GetNeedAsync(int id)
        {
            return await _needRepository.GetAsync(id);
        }

        public Task<ICollection<NeedModel>> GetNeedsAsync(int shelterId, int? animalId)
        {
            throw new NotImplementedException();
        }

        public async Task<NeedModel> SaveNeedAsync(NeedModel model)
        {
            return await _needRepository.SaveAsync(model);
        }

        public async Task DeleteNeedAsync(int id)
        {
            await _needRepository.DeleteAsync(id);
        }
    }
}
