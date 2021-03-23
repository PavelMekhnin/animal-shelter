namespace Mekhnin.Shelter.Context.Shelter
{
    /// <summary>
    /// Base class for models with identity field "Id"
    /// </summary>
    /// <typeparam name="TM">Type of model</typeparam>
    public abstract class BaseModel<TM> : BaseModel
    {
        /// <summary>
        /// Identity field of model
        /// </summary>
        public TM Id { get; set; }
    }

    /// <summary>
    /// Base class-marker for model
    /// </summary>
    public abstract class BaseModel
    {
    }
}
