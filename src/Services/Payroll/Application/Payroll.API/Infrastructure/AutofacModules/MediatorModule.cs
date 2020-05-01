using System.Linq;
using System.Reflection;
using Autofac;
using Payroll.Infrastructure.Data;
using FluentValidation;
using MediatR;
using Payroll.API.Application.Validations;
using Payroll.Application.Behaviors;
using Payroll.Application.Commands.Payments;
using Payroll.Application.DomainEventHandlers.Audit;
using Payroll.DomainCore.AggregatesModel.TaxAggregate;

namespace Payroll.API.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
                       

            // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
            builder.RegisterAssemblyTypes(typeof(GeneratePaymentCmd).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));


            // Register the DomainEventHandler classes (they implement INotificationHandler<>) in assembly holding the Domain Events
            builder.RegisterAssemblyTypes(typeof(PaymentGeneratedAuditEventHander).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(typeof(GeneratePaymentCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();


            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            //services.AddScoped(typeof(IUniversityRepository), typeof(UniversitySqlServerRepository));

            //register behaviors
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));  //logging
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));  //validator


            //APPLICATION MODULES


            builder.RegisterType<TaxRepository>()
                  .As<ITaxRepository>()
                  .InstancePerLifetimeScope();



        }


    }
}


