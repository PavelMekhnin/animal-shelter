using System.Collections.Generic;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mekhnin.Shelter.Controllers
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

        // GET: api/<controller>
        [HttpGet("shelter/{shelterId}")]
        public async Task<IEnumerable<AnimalCard>> GetByShelterAsync(int shelterId)
        {
            var models = await _animalService.GetAnimalsAsync(shelterId, null);

            var result = new List<AnimalCard>();

            foreach (var animalModel in models)
            {
                result.Add(_viewModelMapper.Map(animalModel));
            }

            return result;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<AnimalCard> GetAsync(int id)
        {
            var model = await _animalService.GetAnimalAsync(id);

            return _viewModelMapper.Map(model);

            return new AnimalCard()
            {
                Id = 1,
                Name = "Лелик",
                Description = "Хромой",
                ImgUrl = "https://images.theconversation.com/files/250401/original/file-20181213-110249-1czg7z.jpg",
                Age = 13,
                Bio = "хромой красавец",
                Race = "Буденовская",
                Volunteers = new List<VolunteerCardPreview>()
                {
                    new VolunteerCardPreview()
                    {
                        Id = 1,
                        FirstName = "Павел",
                        LastName = "Мехнин",
                        Phone = "+ 7 913 715 67 48",
                        ImgUrl = "https://конныйспорт.екатеринбург.рф/media/news/news_8570_image_900x_.jpg"
                    }
                },
                Needs = new List<Need>()
                {
                    new Need()
                    {
                        Id = 1,
                        Title = "Лекарство",
                        Count = 1,
                        IsDone = false,
                        Description = "для лелика"
                    },
                    new Need()
                    {
                        Id = 1,
                        Title = "Лекарство 2",
                        Count = 2,
                        IsDone = false,
                        Description = "для лелика"
                    }
                }
            };
        }

        [HttpPost()]
        public async Task<AnimalCard> PostAsync([FromBody]AnimalCard value)
        {
            var model = _viewModelMapper.Map(value);

            model = await _animalService.SaveAnimalAsync(model);

            return _viewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<AnimalCard> PutAsync([FromRoute] int id, [FromBody]AnimalCard value)
        {
            value.Id = id;
            var model = _viewModelMapper.Map(value);

            model = await _animalService.SaveAnimalAsync(model);

            return _viewModelMapper.Map(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _animalService.DeleteAnimalAsync(id);
        }
    }
}
