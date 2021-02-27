using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

namespace Mekhnin.Shelter.Api.Controllers
{
    [Route("api/[controller]")]
    public class AnimalsController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IAnimalViewModelMapper _viewModelMapper;

        public AnimalsController(
            IAnimalService animalService,
            IAnimalViewModelMapper viewModelMapper
            )
        {
            _animalService = animalService;
            _viewModelMapper = viewModelMapper;
        }

        [HttpGet("shelter/{shelterId}")]
        public async Task<IEnumerable<AnimalCard>> GetByShelterAsync(int shelterId, CancellationToken cancellationToken)
        {
            var models = await _animalService.GetAnimalsAsync(shelterId, null, cancellationToken);

            var result = new List<AnimalCard>();

            foreach (var animalModel in models)
            {
                result.Add(_viewModelMapper.Map(animalModel));
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<AnimalCard> GetAsync(int id, CancellationToken cancellationToken)
        {
            var model = await _animalService.GetAnimalAsync(id, cancellationToken);

            return _viewModelMapper.Map(model);
        }

        [HttpPost()]
        public async Task<AnimalCard> PostAsync([FromBody]AnimalCard value, CancellationToken cancellationToken)
        {
            var model = _viewModelMapper.Map(value);

            model = await _animalService.SaveAnimalAsync(model, cancellationToken);

            return _viewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<AnimalCard> PutAsync([FromRoute] int id, [FromBody]AnimalCard value, CancellationToken cancellationToken)
        {
            value.Id = id;
            var model = _viewModelMapper.Map(value);

            model = await _animalService.SaveAnimalAsync(model, cancellationToken);

            return _viewModelMapper.Map(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _animalService.DeleteAnimalAsync(id, cancellationToken);
        }
    }
}
