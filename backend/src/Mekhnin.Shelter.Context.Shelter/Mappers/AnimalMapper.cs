using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Entities;

namespace Mekhnin.Shelter.Context.Shelter.Mappers
{
    internal class AnimalMapper 
        : IMapper<AnimalModel, Data.Shelter.Entities.Animal>
    {
        public AnimalModel MapToModel(Animal entity)
        {
            return new AnimalModel()
            {
                Id = entity.Id,
                Age = entity.Age,
                Bio = entity.Bio,
                Description = entity.Description,
                ImgUrl = entity.ImgUrl,
                Name = entity.Name,
                Race = entity.Race,
                ShelterId = entity.ShelterId
            };
        }

        public void MapToEntity(AnimalModel model, Animal entity)
        {
            entity.ImgUrl = model.ImgUrl;
            entity.Age = model.Age;
            entity.Bio = model.Bio;
            entity.Description = model.Description;
            entity.Name = model.Name;
            entity.Race = model.Race;
            entity.ShelterId = model.ShelterId;
        }
    }
}
