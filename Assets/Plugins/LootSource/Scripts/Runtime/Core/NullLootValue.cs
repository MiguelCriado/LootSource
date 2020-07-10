namespace LootSource
{
	public class NullLootValue : LootValue<object>
	{
		public NullLootValue(int weight) : base(null, weight, false, false, true)
		{

		}
	}
}
