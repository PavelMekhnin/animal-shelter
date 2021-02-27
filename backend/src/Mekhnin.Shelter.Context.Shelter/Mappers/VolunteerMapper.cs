using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Entities;

namespace Mekhnin.Shelter.Context.Shelter.Mappers
{
    internal class VolunteerMapper 
        : IMapper<VolunteerModel, Data.Shelter.Entities.Volunteer>
    {
        public VolunteerModel MapToModel(Volunteer entity)
        {
            return new VolunteerModel()
            {
                ImgUrl = entity.ImgUrl,
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        public void MapToEntity(VolunteerModel model, Volunteer entity)
        {
            entity.ImgUrl = model.ImgUrl;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
        }
    }
}
