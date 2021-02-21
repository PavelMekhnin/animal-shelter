using System.Collections.Generic;
using System.Threading.Tasks;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.ApplicationService;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mekhnin.Shelter.Controllers
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

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<ShelterCardPreview>> GetListAsync([FromQuery]string searchQuery)
        {
            var models = await _shelterService.GetSheltersAsync(new ShelterSearchParameters()
            {
                Name = searchQuery
            });

            var result= new List<ShelterCardPreview>();

            foreach (var shelterModel in models)
            {
                result.Add(_previewViewModelMapper.Map(shelterModel));
            }

            return result;

            return new List<ShelterCardPreview>()
            {
                new ShelterCardPreview()
                {
                    Id = 1,
                    Title = "Шанс на жизнь",
                    LogoUrl = "https://sun9-7.userapi.com/c852016/v852016218/18ef1f/Ne6MaHZrJaA.jpg",
                    Address = "г. Клин, Московская Обл.",
                    AnimalCount = 72,
                    VolunteerCount = 12
                },
                new ShelterCardPreview()
                {
                    Id = 1,
                    Title = "Дуровая роща",
                    LogoUrl = "https://sun9-7.userapi.com/c852016/v852016218/18ef1f/Ne6MaHZrJaA.jpg",
                    Address = "г. Москва",
                    AnimalCount = 720,
                    VolunteerCount = 12
                }
            };
        }
        
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ShelterCard> GetAsync(int id)
        {
            var model = await _shelterService.GetShelterAsync(id);

            return _shelterViewModelMapper.Map(model);

            return new ShelterCard()
            {
                Address = "г. Клин, Московская Обл.",
                Id = 1,
                LogoUrl = "https://sun9-7.userapi.com/c852016/v852016218/18ef1f/Ne6MaHZrJaA.jpg",
                Title = "Шанс на жизнь",
                Description = "Приют для лоашдей",
                CoverUrl = "https://sun9-52.userapi.com/c850016/v850016567/1bc460/ubjbr2z4hc4.jpg",
                Contacts = new List<Contact>()
                {
                    new Contact()
                    {
                        Owner = "Павел",
                        Type = 1,
                        Value = "+7 913 715 67 48"
                    }
                },
                Animals = new List<AnimalCardPreview>()
                {
                    new AnimalCardPreview()
                    {
                        Id = 1,
                        Name = "Лелик",
                        Description = "Хромой",
                        ImgUrl = "https://images.theconversation.com/files/250401/original/file-20181213-110249-1czg7z.jpg"
                    },
                    new AnimalCardPreview()
                    {
                        Id = 2,
                        Name = "Баря",
                        Description = "Красавица",
                        ImgUrl = "https://zooclub.ru/attach/37000/37055.jpg"
                    },
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
                    },
                },
                Volunteers = new List<VolunteerCardPreview>()
                {
                    new VolunteerCardPreview()
                    {
                        Id = 1,
                        FirstName = "Павел",
                        LastName = "Мехнин",
                        Phone = "+ 7 913 715 67 48",
                        ImgUrl = "https://конныйспорт.екатеринбург.рф/media/news/news_8570_image_900x_.jpg"
                    },
                    new VolunteerCardPreview()
                    {
                        Id = 1,
                        FirstName = "Настя",
                        LastName = "",
                        Phone = "+ 7 913 715 67 48",
                        ImgUrl = "https://s1.stc.all.kpcdn.net/putevoditel/projectid_103889/images/tild3330-3838-4435-a630-393363646261__20140928_zap_p115_01.jpg"
                    }
                }
            };
        }

        // POST api/<controller>
        [HttpPost()]
        public async Task<ShelterCard> PostAsync([FromBody]ShelterCard value)
        {
            var model = _shelterViewModelMapper.Map(value);

            model = await _shelterService.SaveShelterAsync(model);

            return _shelterViewModelMapper.Map(model);
        }

        [HttpPut("{id}")]
        public async Task<ShelterCard> PutAsync([FromRoute]int id, [FromBody]ShelterCard value)
        {
            value.Id = id;
            var model = _shelterViewModelMapper.Map(value);

            model = await _shelterService.SaveShelterAsync(model);

            return _shelterViewModelMapper.Map(model);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _shelterService.DeleteShelterAsync(id);
        }
    }
}
