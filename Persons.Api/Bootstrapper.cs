using AutoMapper;
using Nancy.Hosting.Aspnet;
using Nancy.TinyIoc;
using Persons.Abstractions.Data;
using Persons.Abstractions.Dto;
using Persons.Api.Mapping;
using Serilog;

namespace Persons.Api
{
    public class Bootstrapper : DefaultNancyAspNetBootstrapper
    {
        private MapperConfiguration _mapperConfiguration;

        public Bootstrapper() : base()
        {
            _mapperConfiguration = new MapperConfiguration(p => p.AddProfile(new PersonProfile()));
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IRepository, Repository>().AsSingleton();
            container.Register<IMapper>(_mapperConfiguration.CreateMapper());
            container.Register<ILogger>(new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger());
        }
    }
}