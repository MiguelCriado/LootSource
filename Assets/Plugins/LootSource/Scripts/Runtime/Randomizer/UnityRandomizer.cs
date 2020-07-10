using UnityEngine;

namespace LootSource
{
	public class UnityRandomizer : IRandomizer
	{
		public float GetFloat(float min, float max)
		{
			return Random.Range(min, max);
		}

		public float GetFloat(float max)
		{
			return GetFloat(0, max);
		}

		public int GetInt(int min, int max)
		{
			return Random.Range(min, max);
		}

		public int GetInt(int max)
		{
			return GetInt(0, max);
		}

		public bool IsPercentHit(float percent)
		{
			return GetFloat(1) >= percent;
		}
	}
}
