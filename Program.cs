using System;
using System.Threading.Tasks;
using DI.entities;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
	class Program
	{
		static void Main(string[] args)
		{
			var serviceCollection = new ServiceCollection();
			var singleInstance = SingleToneClass.Instance;
			System.Console.WriteLine($"Main method SingleTone Class Id: {singleInstance.GetHashCode().ToString()}");
			serviceCollection.AddSingleton<Configuration>();
			serviceCollection.AddScoped<ScopeClass>();
			serviceCollection.AddTransient<TransientClass>();
			IServiceProvider builder = serviceCollection.BuildServiceProvider();
			System.Console.WriteLine($"Main method Scoped Class Id: {builder.GetService<ScopeClass>().GetHashCode().ToString()}");
			System.Console.WriteLine($"Main method Configuration Class Id: {builder.GetService<Configuration>().GetHashCode().ToString()}");
			Parallel.For(1, 3, i =>
			{
				InstantiateClasses(builder);
			});
			//System.Console.WriteLine($"SingleTone Class Id: { builder.GetService<SingleToneClass>().GetHashCode().ToString() }");
		}

		static void InstantiateClasses(IServiceProvider builder)
		{
			var singleToneInstance = SingleToneClass.Instance;
			System.Console.WriteLine($"SingleTone Class Id: {singleToneInstance.GetHashCode().ToString() }");
			System.Console.WriteLine($"Scoped Class Id: {builder.GetService<ScopeClass>().GetHashCode().ToString()}");
			System.Console.WriteLine($"Transient Class Id : { builder.GetService<TransientClass>().GetHashCode().ToString()}");
			System.Console.WriteLine($"Configuration Class Id: {builder.GetService<Configuration>().GetHashCode().ToString()}");
		}
	}
}
