using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;

namespace Mekhnin.Shelter.Context.Shelter.Mappers
{
    internal class ShelterMapper : IMapper<ShelterModel, Data.Shelter.Entities.Shelter>
    {
        public ShelterModel MapToModel(Data.Shelter.Entities.Shelter entity)
        {
            return new ShelterModel()
            {
                Address = entity.Address,
                CoverUrl = entity.CoverUrl,
                Description = entity.Description,
                Id = entity.Id,
                LogoUrl = entity.LogoUrl,
                Title = entity.Title
            };
        }

        public void MapToEntity(ShelterModel model, Data.Shelter.Entities.Shelter entity)
        {
            entity.CoverUrl = model.CoverUrl;
            entity.Address = model.Address;
            entity.Description = model.Description;
            entity.LogoUrl = model.LogoUrl;
            entity.Title = model.Title;
            entity.Id = model.Id;
        }
    }
}
