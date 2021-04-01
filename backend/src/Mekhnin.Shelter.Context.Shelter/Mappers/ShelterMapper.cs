using System.Linq;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Entities;

namespace Mekhnin.Shelter.Context.Shelter.Mappers
{
    internal class ShelterMapper : IMapper<ShelterModel, Data.Shelter.Entities.Shelter>
    {
        private readonly IMapper<AnimalModel, Animal> _animalMapper;
        private readonly IMapper<NeedModel, Need> _needMapper;
        private readonly IMapper<VolunteerModel, Volunteer> _volunteerMapper;

        public ShelterMapper(
            IMapper<AnimalModel, Data.Shelter.Entities.Animal> animalMapper,
            IMapper<NeedModel, Data.Shelter.Entities.Need> needMapper,
            IMapper<VolunteerModel, Data.Shelter.Entities.Volunteer> volunteerMapper

        )
        {
            _animalMapper = animalMapper;
            _needMapper = needMapper;
            _volunteerMapper = volunteerMapper;
        }

        public ShelterModel MapToModel(Data.Shelter.Entities.Shelter entity)
        {
            return new ShelterModel()
            {
                Address = entity.Address,
                CoverUrl = entity.CoverUrl,
                Description = entity.Description,
                Id = entity.Id,
                LogoUrl = entity.LogoUrl,
                Title = entity.Title,
                Animals = entity.Animals?.Select(x => _animalMapper.MapToModel(x)).ToList(),
                Needs = entity.Needs?.Select(x => _needMapper.MapToModel(x)).ToList(),
                Volunteers = entity.ShelterVolunteers?.Select(x => _volunteerMapper.MapToModel(x.Volunteer)).ToList()
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
