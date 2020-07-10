namespace LootSource
{
	public static class Math
	{
		public static int Modulo(int a, int b)
		{
			return ((a % b) + b) % b;
		}
	}
}
