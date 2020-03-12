using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI.entities
{
    public static class EntitiesModule
    {
        public static IServiceCollection AddEntitiesModule(this IServiceCollection services)
        {
            services.AddScoped<IndianTaxation>();
			services.AddScoped<USTaxation>();
			services.AddScoped<Func<Location, ITaxCalculation>>(
				Sp => key =>
				{
					switch (key)
					{
						case Location.India: return Sp.GetService<IndianTaxation>();
						case Location.UnitedState: return Sp.GetService<USTaxation>();
						default: return null;
					}
				}
			);
            
            services.AddScoped<IIncomeTax, IncomeTax>();
            return services;
        }
    }
}