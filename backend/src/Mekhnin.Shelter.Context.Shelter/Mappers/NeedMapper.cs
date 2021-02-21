using System;
using System.Collections.Generic;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Data.Shelter.Entities;

namespace Mekhnin.Shelter.Context.Shelter.Mappers
{
    internal class NeedMapper
        : IMapper<NeedModel, Data.Shelter.Entities.Need>
    {
        public NeedModel MapToModel(Need entity)
        {
            return new NeedModel()
            {
                Id = entity.Id,
                Description = entity.Description,
                Count = entity.Count,
                IsDone = entity.IsDone,
                Title = entity.Title,
                AnimalId = entity.AnimalId,
                ShelterId = entity.ShelterId
            };
        }

        public void MapToEntity(NeedModel model, Need entity)
        {
            entity.Description = model.Description;
            entity.ShelterId = model.ShelterId;
            entity.AnimalId = model.AnimalId;
            entity.Count = model.Count;
            entity.IsDone = model.IsDone;
            entity.Title = model.Title;
        }
    }
}
