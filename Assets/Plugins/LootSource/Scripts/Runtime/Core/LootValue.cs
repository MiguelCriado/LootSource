namespace LootSource
{
	public class LootValue<T> : ILootValue<T>
	{
		public T Value { get; }
		public int Weight { get; set; }
		public bool IsUnique { get; set; }
		public bool AlwaysDrop { get; set; }
		public bool CanBeDropped { get; set; }

		public LootValue(T value, int weight, bool isUnique, bool alwaysDrop, bool canBeDropped)
		{
			Value = value;
			Weight = weight;
			IsUnique = isUnique;
			AlwaysDrop = alwaysDrop;
			CanBeDropped = canBeDropped;
		}
	}
}
