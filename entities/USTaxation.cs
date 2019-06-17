namespace DI.entities
{
	public class USTaxation : ITaxCalculation
	{
		public int Calculate()
		{
			return 3000;
		}
	}
}