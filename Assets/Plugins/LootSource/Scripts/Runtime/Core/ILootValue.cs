namespace LootSource
{
	public interface ILootValue<T> : ILootObject
	{
		T Value { get; }
	}
}
