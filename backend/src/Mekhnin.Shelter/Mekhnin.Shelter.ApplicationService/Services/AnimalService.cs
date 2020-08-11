using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Services
{
    internal class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(
            IAnimalRepository animalRepository
            )
        {
            _animalRepository = animalRepository;
        }

        public async Task<AnimalModel> GetAnimalAsync(int id)
        {
            return await _animalRepository.GetAsync(id);
        }

        public async Task<ICollection<AnimalModel>> GetAnimalsAsync(int shelterId, AnimalSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<AnimalModel> SaveAnimalAsync(AnimalModel model)
        {
            return await _animalRepository.SaveAsync(model);
        }

        public async Task DeleteAnimalAsync(int id)
        {
            await _animalRepository.DeleteAsync(id);
        }

        public Task ArchiveAnimalAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
