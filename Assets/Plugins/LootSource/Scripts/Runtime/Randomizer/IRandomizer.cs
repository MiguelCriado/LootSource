namespace LootSource
{
	public interface IRandomizer
	{
		float GetFloat(float min, float max);
		float GetFloat(float max);
		int GetInt(int min, int max);
		int GetInt(int max);
		bool IsPercentHit(float percent);
	}
}
