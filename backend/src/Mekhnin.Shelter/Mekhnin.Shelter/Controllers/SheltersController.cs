using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mekhnin.Shelter.ViewDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mekhnin.Shelter.Controllers
{
    [Route("api/[controller]")]
    public class SheltersController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ShelterCardPreview> Get()
        {
            return new List<ShelterCardPreview>()
            {
                new ShelterCardPreview()
                {
                    Address = "г. Клин, Московская Обл.",
                    AnimalCount = 76,
                    Id = 1,
                    LogoUrl = "https://sun9-7.userapi.com/c852016/v852016218/18ef1f/Ne6MaHZrJaA.jpg",
                    Title = "Шанс на жизнь",
                    VolunteerCount = 12
                }
            };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ShelterCard Get(int id)
        {
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
                        Type = "phone",
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
                Volunteers =
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
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
