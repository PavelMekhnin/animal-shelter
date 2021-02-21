using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface INeedService
    {
        public Task<NeedModel> GetNeedAsync(int id);
        public Task<ICollection<NeedModel>> GetNeedsAsync(int shelterId, int? animalId);
        public Task<NeedModel> SaveNeedAsync(NeedModel model);
        public Task DeleteNeedAsync(int id);
    }
}
