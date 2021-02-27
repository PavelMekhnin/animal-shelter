using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface INeedService
    {
        public Task<NeedModel> GetNeedAsync(int id, CancellationToken cancellationToken);
        public Task<ICollection<NeedModel>> GetNeedsAsync(int shelterId, int? animalId, CancellationToken cancellationToken);
        public Task<NeedModel> SaveNeedAsync(NeedModel model, CancellationToken cancellationToken);
        public Task DeleteNeedAsync(int id, CancellationToken cancellationToken);
    }
}
