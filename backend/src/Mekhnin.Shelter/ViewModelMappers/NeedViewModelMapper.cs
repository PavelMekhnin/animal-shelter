﻿using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.ViewDto;

namespace Mekhnin.Shelter.Api.ViewModelMappers
{
    public class NeedViewModelMapper : INeedViewModelMapper
    {
        public NeedModel Map(Need viewModel)
        {
            return new NeedModel()
            {
                Id = viewModel.Id,
                AnimalId = viewModel.AnimalId,
                ShelterId = viewModel.ShelterId,
                Description = viewModel.Description,
                Title = viewModel.Title,
                Count = viewModel.Count,
                IsDone = viewModel.IsDone
            };
        }

        public Need Map(NeedModel model)
        {
            return new Need()
            {
                Id = model.Id,
                AnimalId = model.AnimalId,
                ShelterId = model.ShelterId,
                Description = model.Description,
                Count = model.Count,
                IsDone = model.IsDone,
                Title = model.Title
            };
        }
    }
}
