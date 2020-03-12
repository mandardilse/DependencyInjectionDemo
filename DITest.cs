using System;
using DI.entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DependencyInjectionDemo
{
    public class DITest
    {
        private readonly IIncomeTax _incomeTax;
        private readonly IIncomeTax obj;

        public DITest()
        {
            IServiceCollection services = new ServiceCollection();
            //Add Module to register your depedency at one place.
            services.AddEntitiesModule();
            var provider = services.BuildServiceProvider();
            var instance = provider.GetService<Func<Location,ITaxCalculation>>();
            obj = provider.GetService<IIncomeTax>();
            //_incomeTax = new IncomeTax(instance);
        }

        [Fact]
        public void TestDI()
        {
           var c = obj.CalculateIncomeTax(Location.India);
           var d =  obj.CalculateIncomeTax(Location.UnitedState);
        }
    }
}