using System;
using System.Collections.Generic;
using System.Text;
using Mekhnin.Shelter.Data.Shelter;

namespace Mekhnin.Shelter.Context.Shelter.Interfaces
{
    public interface IRepository<TM, TE>
        where TM : class
        where TE : IEntity
    {
    }
}
