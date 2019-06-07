namespace DI.entities
{
	public class SingleToneClass
	{
		private static SingleToneClass instance = null;
		private static readonly object padlock = new object();
		SingleToneClass()
		{

		}
		public static SingleToneClass Instance
		{
			get
			{
				lock (padlock)
				{
					if (instance == null)
						instance = new SingleToneClass();
					return instance;
				}
			}
		}
	}
}