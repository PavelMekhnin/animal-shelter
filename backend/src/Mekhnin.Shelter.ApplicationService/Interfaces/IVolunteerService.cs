using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface IVolunteerService
    {
        public Task<VolunteerModel> GetVolunteerAsync(int id, CancellationToken cancellationToken);
        public Task<ICollection<VolunteerModel>> GetVolunteersAsync(int shelterId, VolunteerSearchParameters parameters, CancellationToken cancellationToken);
        public Task<VolunteerModel> SaveVolunteerAsync(VolunteerModel model, CancellationToken cancellationToken);
        public Task DeleteVolunteerAsync(int id, CancellationToken cancellationToken);
        public Task AttachVolunteerToShelterAsync(int volunteerId, int shelterId, CancellationToken cancellationToken);
        public Task DetachVolunteerFromShelterAsync(int volunteerId, int shelterId, CancellationToken cancellationToken);
        public Task AttachVolunteerToAnimalAsync(int volunteerId, int shelterId, CancellationToken cancellationToken);
        public Task DetachVolunteerFromAnimalAsync(int volunteerId, int shelterId, CancellationToken cancellationToken);
    }
}
