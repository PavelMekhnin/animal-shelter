using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface IAnimalService
    {
        public Task<AnimalModel> GetAnimalAsync(int id, CancellationToken cancellationToken);
        public Task<ICollection<AnimalModel>> GetAnimalsAsync(int shelterId, AnimalSearchParameters parameters, CancellationToken cancellationToken);
        public Task<AnimalModel> SaveAnimalAsync(AnimalModel model, CancellationToken cancellationToken);
        public Task DeleteAnimalAsync(int id, CancellationToken cancellationToken);
        public Task ArchiveAnimalAsync(int id, CancellationToken cancellationToken);
    }
}
