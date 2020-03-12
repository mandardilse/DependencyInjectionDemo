using System;

namespace DI.entities
{
	public class IncomeTax : IIncomeTax
	{
		private readonly Func<Location, ITaxCalculation> _accessor;

		public IncomeTax(Func<Location, ITaxCalculation> accessor) => _accessor = accessor;
		public int CalculateIncomeTax(Location location)
		{
			var taxValue = _accessor(location).Calculate();
			return taxValue;
		}
	}
}