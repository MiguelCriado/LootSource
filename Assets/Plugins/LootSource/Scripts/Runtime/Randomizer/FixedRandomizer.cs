using UnityEngine;

namespace LootSource
{
	public class FixedRandomizer : IRandomizer
	{
		private float[] sequence;
		private int currentIndex;

		public FixedRandomizer(params float[] sequence)
		{
			this.sequence = sequence;

			if (this.sequence == null)
			{
				this.sequence = new float[] {0};
			}

			currentIndex = 0;
		}

		public float GetFloat(float min, float max)
		{
			float result = Mathf.Clamp(sequence[currentIndex], min, max);
			AdvanceIndex();

			return result;
		}

		public float GetFloat(float max)
		{
			return GetFloat(0, max);
		}

		public int GetInt(int min, int max)
		{
			return Mathf.RoundToInt(GetFloat(min, max));
		}

		public int GetInt(int max)
		{
			return GetInt(0, max);
		}

		public bool IsPercentHit(float percent)
		{
			return GetFloat(0, 1) >= percent;
		}

		private void AdvanceIndex()
		{
			currentIndex = Math.Modulo(currentIndex + 1, sequence.Length);
		}
	}
}
