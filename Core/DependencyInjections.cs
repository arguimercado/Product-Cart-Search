using Core.Context;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class DependencyInjections
{
    public static IServiceCollection AddCore(this IServiceCollection services,IConfiguration configuration) {

        services.AddDbContext<ProductContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ProductCartService>();

        return services;
    }
}
