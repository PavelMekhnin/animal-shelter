using System;
using System.Collections.Generic;
using System.Text;
using Mekhnin.Shelter.Data.Shelter;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IMapper<TM, in TE>
        where TM : class
        where TE : IEntity
    {
        public TM MapToModel(TE entity);
        public void MapToEntity(TM model, TE entity);
    }
}
