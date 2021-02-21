using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    public class ShelterViewModelMapper : IShelterViewModelMapper
    {
        public ShelterModel Map(ShelterCard viewModel)
        {
            return new ShelterModel()
            {
                Id = viewModel.Id,
                CoverUrl = viewModel.CoverUrl,
                Description = viewModel.Description,
                LogoUrl = viewModel.LogoUrl,
                Title = viewModel.Title,
                Address = viewModel.Address
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
                LogoUrl = model.LogoUrl
            };
        }
    }
}
