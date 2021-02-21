using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface IShelterService
    {
        public Task<ShelterModel> GetShelterAsync(int id);
        public Task<ICollection<ShelterModel>> GetSheltersAsync(ShelterSearchParameters parameters);
        public Task<ShelterModel> SaveShelterAsync(ShelterModel model);
        public Task DeleteShelterAsync(int id);
    }
}
