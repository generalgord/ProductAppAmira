using MediatR;

using ProductApp.Application.Common.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;
public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection serviceDescriptors)
    {
        var assemblies = Assembly.GetExecutingAssembly();
        serviceDescriptors.AddAutoMapper(assemblies);
        serviceDescriptors.AddMediatR(assemblies);
    }
}
