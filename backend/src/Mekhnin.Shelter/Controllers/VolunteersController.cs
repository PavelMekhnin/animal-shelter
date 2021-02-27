using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

namespace Mekhnin.Shelter.Api.Controllers
{
    [Route("api/volunteers")]
    public class VolunteersController : Controller
    {
        private readonly IVolunteerService _volunteerService;
        private readonly IVolunteerViewModelMapper _volunteerViewModelMapper;

        public VolunteersController(
            IVolunteerService volunteerService,
            IVolunteerViewModelMapper volunteerViewModelMapper
            )
        {
            _volunteerService = volunteerService;
            _volunteerViewModelMapper = volunteerViewModelMapper;
        }

        [HttpGet("shelter/{shelterId}")]
        public async Task<IEnumerable<VolunteerCardPreview>> GetByShelterAsync(int shelterId, CancellationToken cancellationToken)
        {
            var models = await _volunteerService.GetVolunteersAsync(shelterId, null, cancellationToken);

            var result = new List<VolunteerCardPreview>();

            foreach (var volunteerModel in models)
            {
                result.Add(_volunteerViewModelMapper.Map(volunteerModel));
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<VolunteerCardPreview> GetAsync(int id, CancellationToken cancellationToken)
        {
            var model = await _volunteerService.GetVolunteerAsync(id, cancellationToken);

            return _volunteerViewModelMapper.Map(model);
        }

        [HttpPost()]
        public async Task<VolunteerCardPreview> PostAsync([FromBody]VolunteerCardPreview value, CancellationToken cancellationToken)
        {
            var model = _volunteerViewModelMapper.Map(value);

            model = await _volunteerService.SaveVolunteerAsync(model, cancellationToken);

            return _volunteerViewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<VolunteerCardPreview> PutAsync(int id, [FromBody]VolunteerCardPreview value, CancellationToken cancellationToken)
        {
            value.Id = id;
            var model = _volunteerViewModelMapper.Map(value);

            model = await _volunteerService.SaveVolunteerAsync(model, cancellationToken);

            return _volunteerViewModelMapper.Map(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _volunteerService.DeleteVolunteerAsync(id, cancellationToken);
        }
    }
}
