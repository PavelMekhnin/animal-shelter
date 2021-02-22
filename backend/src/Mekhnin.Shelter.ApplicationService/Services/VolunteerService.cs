using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.ApplicationService.Services
{
    internal class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerService(
            IVolunteerRepository volunteerRepository
            )
        {
            _volunteerRepository = volunteerRepository;
        }

        public async Task<VolunteerModel> GetVolunteerAsync(int id, CancellationToken cancellationToken)
        {
            return await _volunteerRepository.GetAsync(id, cancellationToken);
        }

        public Task<ICollection<VolunteerModel>> GetVolunteersAsync(int shelterId, VolunteerSearchParameters parameters, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<VolunteerModel> SaveVolunteerAsync(VolunteerModel model, CancellationToken cancellationToken)
        {
            return await _volunteerRepository.SaveAsync(model, cancellationToken);
        }

        public async Task DeleteVolunteerAsync(int id, CancellationToken cancellationToken)
        {
            await _volunteerRepository.DeleteAsync(id, cancellationToken);
        }

        public Task AttachVolunteerToShelterAsync(int volunteerId, int shelterId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DetachVolunteerFromShelterAsync(int volunteerId, int shelterId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AttachVolunteerToAnimalAsync(int volunteerId, int shelterId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DetachVolunteerFromAnimalAsync(int volunteerId, int shelterId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
