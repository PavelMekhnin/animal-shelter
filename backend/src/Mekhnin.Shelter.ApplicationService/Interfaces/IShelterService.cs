using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface IShelterService
    {
        public Task<ShelterModel> GetShelterAsync(int id, CancellationToken cancellationToken);
        public Task<ICollection<ShelterModel>> GetSheltersAsync(ShelterSearchParameters parameters, CancellationToken cancellationToken);
        public Task<ShelterModel> SaveShelterAsync(ShelterModel model, CancellationToken cancellationToken);
        public Task DeleteShelterAsync(int id, CancellationToken cancellationToken);
    }
}
