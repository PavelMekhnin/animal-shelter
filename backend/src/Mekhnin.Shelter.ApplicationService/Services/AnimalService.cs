using System;
using System.Collections.Generic;
using System.Threading;
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

        public async Task<AnimalModel> GetAnimalAsync(int id, CancellationToken cancellationToken)
        {
            return await _animalRepository.GetAsync(id, cancellationToken);
        }

        public async Task<ICollection<AnimalModel>> GetAnimalsAsync(int shelterId, AnimalSearchParameters parameters, CancellationToken cancellationToken)
        {
            return await _animalRepository.GetListByShelterAsync(shelterId, cancellationToken);
        }

        public async Task<AnimalModel> SaveAnimalAsync(AnimalModel model, CancellationToken cancellationToken)
        {
            return await _animalRepository.SaveAsync(model, cancellationToken);
        }

        public async Task DeleteAnimalAsync(int id, CancellationToken cancellationToken)
        {
            await _animalRepository.DeleteAsync(id, cancellationToken);
        }

        public Task ArchiveAnimalAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
