﻿using BookStore.Repositories.Contracts;
using BookStore.Repositories.EFCore;
using BookStore.Services;
using BookStore.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opt 
                => opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager,RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services)=> 
            services.AddSingleton<ILoggerService, LoggerManager>();
    }
}
