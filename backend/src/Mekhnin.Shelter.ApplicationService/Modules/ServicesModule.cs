using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Mekhnin.Shelter.ApplicationService.Interfaces;
using Mekhnin.Shelter.ApplicationService.Services;
using Mekhnin.Shelter.Context.Shelter.Modules;

namespace Mekhnin.Shelter.ApplicationService.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalService>().As<IAnimalService>();
            builder.RegisterType<NeedService>().As<INeedService>();
            builder.RegisterType<ShelterService>().As<IShelterService>();
            builder.RegisterType<VolunteerService>().As<IVolunteerService>();

            builder.RegisterModule<ContextModule>();

            base.Load(builder);
        }
    }
}
