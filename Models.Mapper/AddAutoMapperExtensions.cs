using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddAutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(config =>
            {
                config.AddProfiles(typeof(AddAutoMapperExtensions).GetTypeInfo().Assembly);
            });
            Mapper.AssertConfigurationIsValid();
            services.AddSingleton(Mapper.Instance);
        }
    }
}
