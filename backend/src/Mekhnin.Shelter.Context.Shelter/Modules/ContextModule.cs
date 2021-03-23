using Autofac;
using Mekhnin.Shelter.Context.Shelter.Interfaces;
using Mekhnin.Shelter.Context.Shelter.Mappers;
using Mekhnin.Shelter.Context.Shelter.Models;
using Mekhnin.Shelter.Context.Shelter.Repositories;
using Mekhnin.Shelter.Data.Shelter.Context;
using Mekhnin.Shelter.Data.Shelter.Entities;

namespace Mekhnin.Shelter.Context.Shelter.Modules
{
    /// <summary>
    /// Context Autofac DI module
    /// </summary>
    public class ContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterType<AnimalRepository>().As<IAnimalRepository>();
            builder.RegisterType<NeedRepository>().As<INeedRepository>();
            builder.RegisterType<VolunteerRepository>().As<IVolunteerRepository>();
            builder.RegisterType<ShelterRepository>().As<IShelterRepository>();

            // Mappers for repositories
            builder.RegisterType<AnimalMapper>().As<IMapper<AnimalModel, Animal>>();
            builder.RegisterType<NeedMapper>().As<IMapper<NeedModel, Need>>();
            builder.RegisterType<VolunteerMapper>().As<IMapper<VolunteerModel, Volunteer>>();
            builder.RegisterType<ShelterMapper>().As<IMapper<ShelterModel, Data.Shelter.Entities.Shelter>>();

            // other
            builder.RegisterType<ContextFactory<ShelterContext>>().As<IBaseContextFactory<ShelterContext>>();
            
            base.Load(builder);
        }
    }
}
