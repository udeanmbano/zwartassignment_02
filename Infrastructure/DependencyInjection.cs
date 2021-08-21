using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZwartsJWTApi.Application.Repositories;
using ZwartsJWTApi.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          

            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IToDoListItemRepository, ToDoListItemRepository>();
            services.AddTransient<IToLogin,ToLoginRepository>();
            services.AddTransient<IToRegister,ToRegisterRepository>();
            return services;
        }
    }
}