﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
