using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    public class VolunteerViewModelMapper : IVolunteerViewModelMapper
    {
        public VolunteerModel Map(VolunteerCardPreview viewModel)
        {
            return new VolunteerModel()
            {
                Id = viewModel.Id,
                ImgUrl = viewModel.ImgUrl,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Phone = viewModel.Phone
            };
        }

        public VolunteerCardPreview Map(VolunteerModel model)
        {
            return new VolunteerCardPreview()
            {
                Id = model.Id,
                ImgUrl = model.ImgUrl,
                FirstName = model.FirstName,
                Phone = model.Phone,
                LastName = model.LastName
            };
        }
    }
}
