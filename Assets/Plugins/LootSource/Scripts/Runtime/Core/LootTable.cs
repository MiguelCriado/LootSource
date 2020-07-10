using System;
using System.Collections.Generic;

namespace LootSource
{
	public class LootTable : ILootTable
	{
		public event EventHandler<LootTableContentsEventArgs> Rolling;
		public event EventHandler<LootObjectEventArgs> ObjectHitted;
		public event EventHandler<LootTableContentsEventArgs> Rolled;

		public int DefaultDropCount { get; set; }
		public IEnumerable<ILootObject> Contents => contents;

		private List<ILootObject> contents;
		private IRandomizer randomizer;
		private List<ILootObject> dropList;
		private List<ILootObject> uniqueDrops;
		private List<ILootObject> dropables;

		public LootTable(int defaultDropCount)
		{
			DefaultDropCount = defaultDropCount;
			contents = new List<ILootObject>();
			randomizer = new UnityRandomizer();
			dropList = new List<ILootObject>();
			uniqueDrops = new List<ILootObject>();
			dropables = new List<ILootObject>();
		}

		public IEnumerable<ILootObject> Roll()
		{
			return Roll(DefaultDropCount);
		}

		public IEnumerable<ILootObject> Roll(int dropCount)
		{
			dropList.Clear();
			uniqueDrops.Clear();

			OnRolling();

			foreach (ILootObject lootObject in contents.FindAll(x => x.AlwaysDrop))
			{
				AddToDropList(lootObject);
			}

			int realDropCount = dropCount - dropList.Count;

			if (realDropCount > 0)
			{
				dropables.Clear();

				for (int i = 0; i < realDropCount; i++)
				{
					dropables.AddRange(contents.FindAll(x => x.CanBeDropped && !x.AlwaysDrop));
					int totalWeight = GetTotalWeight(dropables);
					int hitValue = randomizer.GetInt(totalWeight);
					int runningValue = 0;
					int dropablesIndex = 0;

					while (hitValue < runningValue && dropablesIndex < dropables.Count)
					{
						ILootObject lootObject = dropables[dropablesIndex];
						runningValue += lootObject.Weight;

						if (hitValue < runningValue)
						{
							AddToDropList(lootObject);
						}

						dropablesIndex++;
					}
				}
			}

			OnRolled();

			return dropList;
		}

		protected virtual void OnRolling()
		{
			Rolling?.Invoke(this, new LootTableContentsEventArgs(Contents));
		}

		protected virtual void OnObjectHitted(ILootObject lootObject)
		{
			ObjectHitted?.Invoke(this, new LootObjectEventArgs(lootObject));
		}

		protected virtual void OnRolled()
		{
			Rolled?.Invoke(this, new LootTableContentsEventArgs(Contents));
		}

		private static int GetTotalWeight(List<ILootObject> candidates)
		{
			int result = 0;

			foreach (ILootObject lootObject in candidates)
			{
				result += lootObject.Weight;
			}

			return result;
		}

		private void AddToDropList(ILootObject lootObject)
		{
			if (lootObject.IsUnique == false || uniqueDrops.Contains(lootObject) == false)
			{
				if (lootObject.IsUnique)
				{
					uniqueDrops.Add(lootObject);
				}

				if (lootObject is NullLootValue == false)
				{
					if (lootObject is ILootTable)
					{
						dropList.AddRange(((ILootTable)lootObject).Roll());
					}
					else
					{
						dropList.Add(lootObject);
						OnObjectHitted(lootObject);
					}
				}
			}
		}
	}
}
