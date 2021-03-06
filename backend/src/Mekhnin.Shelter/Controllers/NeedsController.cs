﻿using System.Collections.Generic;
using System.Threading;
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
        public async Task<IEnumerable<Need>> GetByShelterAsync(int shelterId, CancellationToken cancellationToken)
        {
            var models = await _needService.GetNeedsAsync(shelterId, null, cancellationToken);

            var result = new List<Need>();

            foreach (var needModel in models)
            {
                result.Add(_viewModelMapper.Map(needModel));
            }

            return result;
        }

        [HttpPost()]
        public async Task<Need> SaveAsync([FromBody]Need viewModel, CancellationToken cancellationToken)
        {
            var model = _viewModelMapper.Map(viewModel);
            model = await _needService.SaveNeedAsync(model, cancellationToken);

            return _viewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<Need> PutAsync([FromRoute]int id, [FromBody]Need viewModel, CancellationToken cancellationToken)
        {
            viewModel.Id = id;
            var model = _viewModelMapper.Map(viewModel);
            model = await _needService.SaveNeedAsync(model, cancellationToken);

            return _viewModelMapper.Map(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync([FromRoute]int id, CancellationToken cancellationToken)
        {
            await _needService.DeleteNeedAsync(id, cancellationToken);
        }
    }
}
