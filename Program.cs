using System;
using System.Threading.Tasks;
using DI.entities;
using Microsoft.Extensions.DependencyInjection;
//Use README instructions
namespace DI
{
	class Program
	{
		static void Main(string[] args)
		{
			//Step 1
			var serviceCollection = new ServiceCollection();
			//for demo purpose, used actual single tone class and create instance.
			var singleInstance = SingleToneClass.Instance;
			System.Console.WriteLine($"Main method SingleTone Class Id: {singleInstance.GetHashCode().ToString()}");

			serviceCollection.AddSingleton<Configuration>();
			serviceCollection.AddScoped<ScopeClass>();
			serviceCollection.AddTransient<TransientClass>();

			//Step 2
			IServiceProvider builder = serviceCollection.BuildServiceProvider();
			System.Console.WriteLine($"Main method Scoped Class Id: {builder.GetService<ScopeClass>().GetHashCode().ToString()}");
			System.Console.WriteLine($"Main method Configuration Class Id: {builder.GetService<Configuration>().GetHashCode().ToString()}");
			Parallel.For(1, 3, i =>
			{
				InstantiateClasses(builder);
			});
		}

		static void InstantiateClasses(IServiceProvider builder)
		{
			var singleToneInstance = SingleToneClass.Instance;
			//Step 3
			System.Console.WriteLine($"SingleTone Class Id: {singleToneInstance.GetHashCode().ToString() }");
			System.Console.WriteLine($"Scoped Class Id: {builder.GetService<ScopeClass>().GetHashCode().ToString()}");
			System.Console.WriteLine($"Transient Class Id : { builder.GetService<TransientClass>().GetHashCode().ToString()}");
			System.Console.WriteLine($"Configuration Class Id: {builder.GetService<Configuration>().GetHashCode().ToString()}");
		}
	}
}
