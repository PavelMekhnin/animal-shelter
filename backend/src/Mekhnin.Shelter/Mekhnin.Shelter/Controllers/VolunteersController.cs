using System.Collections.Generic;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mekhnin.Shelter.Controllers
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

        // GET: api/<controller>
        [HttpGet("shelter/{shelterId}")]
        public async Task<IEnumerable<VolunteerCardPreview>> GetByShelterAsync(int shelterId)
        {
            var models = await _volunteerService.GetVolunteersAsync(shelterId, null);

            var result = new List<VolunteerCardPreview>();

            foreach (var volunteerModel in models)
            {
                result.Add(_volunteerViewModelMapper.Map(volunteerModel));
            }

            return result;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<VolunteerCardPreview> GetAsync(int id)
        {
            var model = await _volunteerService.GetVolunteerAsync(id);

            return _volunteerViewModelMapper.Map(model);

            return new VolunteerCardPreview()
            {
                Id = 1,
                FirstName = "Павел",
                LastName = "Мехнин",
                Phone = "+ 7 913 715 67 48",
                ImgUrl = "https://конныйспорт.екатеринбург.рф/media/news/news_8570_image_900x_.jpg"
            };
        }

        // POST api/<controller>
        [HttpPost("{id}")]
        public async Task<VolunteerCardPreview> PostAsync(int id, [FromBody]VolunteerCardPreview value)
        {
            var model = _volunteerViewModelMapper.Map(value);

            model = await _volunteerService.SaveVolunteerAsync(model);

            return _volunteerViewModelMapper.Map(model);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _volunteerService.DeleteVolunteerAsync(id);
        }
    }
}
