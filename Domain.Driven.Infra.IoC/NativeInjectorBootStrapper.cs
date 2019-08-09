using Domain.Driven.Application.Interfaces;
using Domain.Driven.Application.Services;
using Domain.Driven.Core.Bus;
using Domain.Driven.Core.Notifications;
using Domain.Driven.Data.Context;
using Domain.Driven.Data.Repository;
using Domain.Driven.Data.UoW;
using Domain.Driven.Domain.CommandHandlers.Student;
using Domain.Driven.Domain.Commands.Student;
using Domain.Driven.Domain.EventHandlers.StudentEventHandlers;
using Domain.Driven.Domain.Events;
using Domain.Driven.Domain.Interfaces;
using Domain.Driven.Domain.Notifications;
using Domain.Driven.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Driven.Infra.IoC
{
    /// <summary>
    /// 统一注入类
    /// </summary>
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IStudentAppService, StudentAppService>();

            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<StudyContext>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //services.AddScoped(typeof(IUnitOfWork<>), typeof(IUnitOfWork<>));

            services.AddScoped<IUnitOfWork,UnitOfWork>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();

            //domain -events
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemoveEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentUpdateEvent>, StudentEventHandler>();

            //domain  将事件模型和事件处理程序匹配注入  ->领域通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}