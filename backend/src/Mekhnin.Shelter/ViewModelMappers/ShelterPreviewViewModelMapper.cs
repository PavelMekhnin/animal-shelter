using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    internal class ShelterPreviewViewModelMapper : IShelterPreviewViewModelMapper
    {
        public ShelterModel Map(ShelterCardPreview viewModel)
        {
            return new ShelterModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                LogoUrl = viewModel.LogoUrl
            };
        }

        public ShelterCardPreview Map(ShelterModel model)
        {
            return new ShelterCardPreview()
            {
                Id = model.Id,
                Title = model.Title,
                LogoUrl = model.LogoUrl,
                Address = model.Address
            };
        }
    }
}
