namespace LootSource
{
	public interface ILootObject
	{
		int Weight { get; set; }
		bool IsUnique { get; set; }
		bool AlwaysDrop { get; set; }
		bool CanBeDropped { get; set; }
	}
}
