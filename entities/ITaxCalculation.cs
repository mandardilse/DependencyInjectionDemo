namespace DI.entities
{
	public enum Location
	{
		India,
		UnitedState
	}
	public interface ITaxCalculation
	{
		int Calculate();
	}
}