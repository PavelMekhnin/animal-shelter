using Autofac;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Mappers;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Context.Shelter.Repositories;
using Mekhnin.Shelter.Data.Shelter.Context;
using Mekhnin.Shelter.Data.Shelter.Entities;

namespace Mekhnin.Shelter.Context.Shelter.Modules
{
    public class ContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalRepository>().As<IAnimalRepository>();
            builder.RegisterType<NeedRepository>().As<INeedRepository>();
            builder.RegisterType<VolunteerRepository>().As<IVolunteerRepository>();
            builder.RegisterType<ShelterRepository>().As<IShelterRepository>();

            builder.RegisterType<AnimalMapper>().As<IMapper<AnimalModel, Animal>>();
            builder.RegisterType<NeedMapper>().As<IMapper<NeedModel, Need>>();
            builder.RegisterType<VolunteerMapper>().As<IMapper<VolunteerModel, Volunteer>>();
            builder.RegisterType<ShelterMapper>().As<IMapper<ShelterModel, Data.Shelter.Entities.Shelter>>();

            builder.RegisterType<ContextFactory<ShelterContext>>().As<IBaseContextFactory<ShelterContext>>();
            
            base.Load(builder);
        }
    }
}
