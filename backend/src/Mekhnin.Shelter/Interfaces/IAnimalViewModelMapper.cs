using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.Interfaces
{
    public interface IAnimalViewModelMapper : IViewModelMapper<AnimalModel, AnimalCard>
    {
    }
}
