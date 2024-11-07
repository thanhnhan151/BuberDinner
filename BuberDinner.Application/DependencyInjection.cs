﻿using BuberDinner.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            //options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            //options.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}
