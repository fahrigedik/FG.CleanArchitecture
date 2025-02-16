using Autofac;
using Domain.Repositories;
using Domain.Services;
using Domain.UnitOfWork;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitOfWork;
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

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();


        base.Load(builder);
    }
}
