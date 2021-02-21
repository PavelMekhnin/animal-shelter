using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Interfaces
{
    public interface IVolunteerService
    {
        public Task<VolunteerModel> GetVolunteerAsync(int id);
        public Task<ICollection<VolunteerModel>> GetVolunteersAsync(int shelterId, VolunteerSearchParameters parameters);
        public Task<VolunteerModel> SaveVolunteerAsync(VolunteerModel model);
        public Task DeleteVolunteerAsync(int id);
        public Task AttachVolunteerToShelterAsync(int volunteerId, int shelterId);
        public Task DetachVolunteerFromShelterAsync(int volunteerId, int shelterId);
        public Task AttachVolunteerToAnimalAsync(int volunteerId, int shelterId);
        public Task DetachVolunteerFromAnimalAsync(int volunteerId, int shelterId);
    }
}
