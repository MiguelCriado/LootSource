using System;
using System.Collections.Generic;

namespace LootSource
{
	public class LootTableContentsEventArgs : EventArgs
	{
		public IEnumerable<ILootObject> Contents { get;}

		public LootTableContentsEventArgs(IEnumerable<ILootObject> contents)
		{
			Contents = contents;
		}
	}

	public class LootObjectEventArgs : EventArgs
	{
		public ILootObject LootObject { get; }

		public LootObjectEventArgs(ILootObject lootObject)
		{
			LootObject = lootObject;
		}
	}

	public interface ILootTable
	{
		event EventHandler<LootTableContentsEventArgs> Rolling;
		event EventHandler<LootObjectEventArgs> ObjectHitted;
		event EventHandler<LootTableContentsEventArgs> Rolled;

		int DefaultDropCount { get; set; }
		IEnumerable<ILootObject> Contents { get; }

		IEnumerable<ILootObject> Roll();
		IEnumerable<ILootObject> Roll(int dropCount);
	}
}
