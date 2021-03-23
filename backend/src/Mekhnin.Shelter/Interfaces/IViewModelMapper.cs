using Mekhnin.Shelter.Context.Shelter;

namespace Mekhnin.Shelter.Api.Interfaces
{
    /// <summary>
    /// ViewModel to Model and Model to ViewModel mapper
    /// </summary>
    /// <typeparam name="TM">Type of Model</typeparam>
    /// <typeparam name="TV">Type of ViewModel</typeparam>
    public interface IViewModelMapper<TM, TV>
    where TM : BaseModel
    where TV : class
    {
        /// <summary>
        /// Map ViewModel to Model
        /// </summary>
        /// <param name="viewModel">ViewModel</param>
        /// <returns>New Model</returns>
        public TM Map(TV viewModel);

        /// <summary>
        /// Map Model to ViewModel
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>New ViewModel</returns>
        public TV Map(TM model);
    }
}
