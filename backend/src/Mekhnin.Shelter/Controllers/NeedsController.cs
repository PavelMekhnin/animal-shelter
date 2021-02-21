using System.Collections.Generic;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

namespace Mekhnin.Shelter.Api.Controllers
{
    [Route("api/[controller]")]
    public class NeedsController : Controller
    {
        private readonly INeedService _needService;
        private readonly INeedViewModelMapper _viewModelMapper;

        public NeedsController(
            INeedService needService,
            INeedViewModelMapper viewModelMapper
        )
        {
            _needService = needService;
            _viewModelMapper = viewModelMapper;
        }

        [HttpGet("shelter/{shelterId}")]
        public async Task<IEnumerable<Need>> GetByShelterAsync(int shelterId)
        {
            var models = await _needService.GetNeedsAsync(shelterId, null);

            var result = new List<Need>();

            foreach (var needModel in models)
            {
                result.Add(_viewModelMapper.Map(needModel));
            }

            return result;
        }

        [HttpPost()]
        public async Task<Need> SaveAsync([FromBody]Need viewModel)
        {
            var model = _viewModelMapper.Map(viewModel);
            model = await _needService.SaveNeedAsync(model);

            return _viewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<Need> PutAsync([FromRoute]int id, [FromBody]Need viewModel)
        {
            viewModel.Id = id;
            var model = _viewModelMapper.Map(viewModel);
            model = await _needService.SaveNeedAsync(model);

            return _viewModelMapper.Map(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute]int id)
        {
            await _needService.DeleteNeedAsync(id);
        }
    }
}
