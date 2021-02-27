namespace Mekhnin.Shelter.Context.Shelter
{
    public abstract class BaseModel<TM> : BaseModel
    {
        public TM Id { get; set; }
    }

    public abstract class BaseModel
    {
    }
}
