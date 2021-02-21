using Autofac;
using Mekhnin.Shelter.Api.Interfaces;
using Mekhnin.Shelter.Api.ViewModelMappers;
using Mekhnin.Shelter.ApplicationService.Modules;

namespace Mekhnin.Shelter.Api.Modules
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnimalViewModelMapper>().As<IAnimalViewModelMapper>();
            builder.RegisterType<ContactViewModelMapper>().As<IContactViewModelMapper>();
            builder.RegisterType<NeedViewModelMapper>().As<INeedViewModelMapper>();
            builder.RegisterType<ShelterViewModelMapper>().As<IShelterViewModelMapper>();
            builder.RegisterType<VolunteerViewModelMapper>().As<IVolunteerViewModelMapper>();
            builder.RegisterType<ShelterPreviewViewModelMapper>().As<IShelterPreviewViewModelMapper>();

            builder.RegisterModule<ServicesModule>();

            base.Load(builder);
        }
    }
}
