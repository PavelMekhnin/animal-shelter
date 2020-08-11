using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface IAnimalService
    {
        public Task<AnimalModel> GetAnimalAsync(int id);
        public Task<ICollection<AnimalModel>> GetAnimalsAsync(int shelterId, AnimalSearchParameters parameters);
        public Task<AnimalModel> SaveAnimalAsync(AnimalModel model);
        public Task DeleteAnimalAsync(int id);
        public Task ArchiveAnimalAsync(int id);
    }
}
