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
    public class AnimalsController : Controller
    {
        // GET: api/<controller>
        [HttpGet()]
        public IEnumerable<AnimalCardPreview> Get()
        {
            return new List<AnimalCardPreview>();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public AnimalCard Get(int id)
        {
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
