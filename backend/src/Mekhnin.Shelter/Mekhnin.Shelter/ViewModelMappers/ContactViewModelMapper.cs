using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    public class ContactViewModelMapper : IContactViewModelMapper
    {
        public ContactModel Map(Contact viewModel)
        {
            return new ContactModel()
            {
                Id = viewModel.Id,
                Type = viewModel.Type,
                Value = viewModel.Value,
                VolunteerId = viewModel.VolunteerId
            };
        }

        public Contact Map(ContactModel model)
        {
            return new Contact()
            {
                Id = model.Id,
                Value = model.Value,
                Type = model.Type,
                VolunteerId = model.VolunteerId
            };
        }
    }
}
