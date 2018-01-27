﻿using System;
using AutoMapper;
using Butterfly.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Butterfly.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryStorage(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (configuration.EnableInMemoryStorage())
            {
                services.AddAutoMapper(config =>
                {
                    config.AddProfile<MappingProfile>();
                });
                services.AddDbContextPool<InMemoryDbContext>(options =>
                {
                    options.UseInMemoryDatabase("--Butterfly--");
                });
                services.AddScoped<ISpanStorage, InMemorySpanStorage>();
                services.AddScoped<ISpanQuery, InMemorySpanQuery>();
                services.AddScoped<IServiceQuery, InMemoryServiceQuery>();
                services.AddScoped<IServiceStorage, InMemoryServiceStorage>();
            }

            return services;
        }
    }
}