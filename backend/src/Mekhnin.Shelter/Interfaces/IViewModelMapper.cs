using Mekhnin.Shelter.Context.Shelter;

namespace Mekhnin.Shelter.Api.Interfaces
{
    public interface IViewModelMapper<TM, TV>
    where TM : BaseModel
    where TV : class
    {
        public TM Map(TV viewModel);
        public TV Map(TM model);
    }
}
