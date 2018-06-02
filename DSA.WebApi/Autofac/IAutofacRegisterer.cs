using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RCS.WebApi.Autofac
{
    internal interface IAutofacRegisterer
    {
        void RegisterModules(IEnumerable<AssemblyName> assemblyNames);
        void RegisterConfiguration(IConfiguration configuration);
        void Populate(IServiceCollection services);
        IServiceProvider GetServiceProvider();
    }
}
