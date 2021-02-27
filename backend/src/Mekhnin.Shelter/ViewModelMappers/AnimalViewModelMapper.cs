using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    public class AnimalViewModelMapper : IAnimalViewModelMapper
    {
        public AnimalModel Map(AnimalCard viewModel)
        {
            return new AnimalModel()
            {
                Description = viewModel.Description,
                Id = viewModel.Id,
                ShelterId = viewModel.ShelterId,
                Age = viewModel.Age,
                Bio = viewModel.Bio,
                ImgUrl = viewModel.ImgUrl,
                Name = viewModel.Name,
                Race = viewModel.Race
            };
        }

        public AnimalCard Map(AnimalModel model)
        {
            return new AnimalCard()
            {
                Id = model.Id,
                ShelterId = model.ShelterId,
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                Race = model.Race,
                Description = model.Description,
                Bio = model.Bio,
                Age = model.Age
            };
        }
    }
}
