using System.Linq;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    public class ShelterViewModelMapper : IShelterViewModelMapper
    {
        private readonly IAnimalViewModelMapper _animalViewModelMapper;
        private readonly INeedViewModelMapper _needViewModelMapper;
        private readonly IVolunteerViewModelMapper _volunteerViewModelMapper;

        public ShelterViewModelMapper(
            IAnimalViewModelMapper animalViewModelMapper,
            INeedViewModelMapper needViewModelMapper,
            IVolunteerViewModelMapper volunteerViewModelMapper
            )
        {
            _animalViewModelMapper = animalViewModelMapper;
            _needViewModelMapper = needViewModelMapper;
            _volunteerViewModelMapper = volunteerViewModelMapper;
        }

        public ShelterModel Map(ShelterCard viewModel)
        {
            return new ShelterModel()
            {
                Id = viewModel.Id,
                CoverUrl = viewModel.CoverUrl,
                Description = viewModel.Description,
                LogoUrl = viewModel.LogoUrl,
                Title = viewModel.Title,
                Address = viewModel.Address,
            };
        }

        public ShelterCard Map(ShelterModel model)
        {
            return new ShelterCard()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                Address = model.Address,
                CoverUrl = model.CoverUrl,
                LogoUrl = model.LogoUrl,
                Animals = model.Animals?.Select(x => _animalViewModelMapper.Map(x)).ToList(),
                Needs = model.Needs?.Select(x => _needViewModelMapper.Map(x)).ToList(),
                Volunteers = model.Volunteers?.Select(x => _volunteerViewModelMapper.Map(x)).ToList()
            };
        }
    }
}
