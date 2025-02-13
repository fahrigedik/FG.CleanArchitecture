using Autofac;
using Domain.Repositories;
using Domain.Services;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;

namespace Infrastructure;
public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        //Register Services
        builder.RegisterType<JwtProvider>().As<IJwtProvider>().InstancePerLifetimeScope();


        //Register Repositories
        builder.RegisterGeneric(typeof(GenericRepository<>))
            .As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();
        builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();



        base.Load(builder);
    }
}
