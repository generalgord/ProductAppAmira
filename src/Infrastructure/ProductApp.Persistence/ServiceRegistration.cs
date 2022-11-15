using Microsoft.EntityFrameworkCore;

using ProductApp.Application.Common.Repositories;
using ProductApp.Infrastructure.Context;
using ProductApp.Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceDescriptors)
    {
        serviceDescriptors.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDB"));
        serviceDescriptors.AddTransient<IProductRepository, ProductRepository>();
    }
}
