using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

namespace Mekhnin.Shelter.Api.Controllers
{
    [Route("api/[controller]")]
    public class SheltersController : Controller
    {
        private readonly IShelterService _shelterService;
        private readonly IShelterViewModelMapper _shelterViewModelMapper;
        private readonly IShelterPreviewViewModelMapper _previewViewModelMapper;

        public SheltersController(
            IShelterService shelterService,
            IShelterViewModelMapper shelterViewModelMapper,
            IShelterPreviewViewModelMapper previewViewModelMapper
            )
        {
            _shelterService = shelterService;
            _shelterViewModelMapper = shelterViewModelMapper;
            _previewViewModelMapper = previewViewModelMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ShelterCardPreview>> GetListAsync([FromQuery]string searchQuery, CancellationToken cancellationToken)
        {
            var models = await _shelterService.GetSheltersAsync(new ShelterSearchParameters()
            {
                Name = searchQuery
            }, cancellationToken);

            var result= new List<ShelterCardPreview>();

            foreach (var shelterModel in models)
            {
                result.Add(_previewViewModelMapper.Map(shelterModel));
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ShelterCard> GetAsync(int id, CancellationToken cancellationToken)
        {
            var model = await _shelterService.GetShelterAsync(id, cancellationToken);

            return _shelterViewModelMapper.Map(model);
        }

        [HttpPost()]
        public async Task<ShelterCard> PostAsync([FromBody]ShelterCard value, CancellationToken cancellationToken)
        {
            var model = _shelterViewModelMapper.Map(value);

            model = await _shelterService.SaveShelterAsync(model, cancellationToken);

            return _shelterViewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<ShelterCard> PutAsync([FromRoute]int id, [FromBody]ShelterCard value, CancellationToken cancellationToken)
        {
            value.Id = id;
            var model = _shelterViewModelMapper.Map(value);

            model = await _shelterService.SaveShelterAsync(model, cancellationToken);

            return _shelterViewModelMapper.Map(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _shelterService.DeleteShelterAsync(id, cancellationToken);
        }
    }
}
