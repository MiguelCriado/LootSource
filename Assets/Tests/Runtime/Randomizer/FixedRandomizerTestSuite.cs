using NUnit.Framework;

namespace LootSource.Tests
{
	public class FixedRandomizerTestSuite
	{
		[Test]
		public void GetFloat_WhenGettingSeveralValues_InputSequenceIsPreserved()
		{
			FixedRandomizer randomizer = new FixedRandomizer(2.3f, 9.44f, 6.458f);

			Assert.AreEqual(2.3f, randomizer.GetFloat(100));
			Assert.AreEqual(9.44f, randomizer.GetFloat(100));
			Assert.AreEqual(6.458f, randomizer.GetFloat(100));
		}

		[Test]
		public void GetFloat_WhenGettingValuesBeyondSequenceLength_RestartSequence()
		{
			FixedRandomizer randomizer = new FixedRandomizer(2.3f, 9.44f, 6.458f);

			Assert.AreEqual(2.3f, randomizer.GetFloat(100));
			Assert.AreEqual(9.44f, randomizer.GetFloat(100));
			Assert.AreEqual(6.458f, randomizer.GetFloat(100));
			Assert.AreEqual(2.3f, randomizer.GetFloat(100));
		}

		[Test]
		public void GetFloat_WhenGettingValueHigherThanMax_ReturnMax()
		{
			FixedRandomizer randomizer = new FixedRandomizer(2.3f, 9.44f, 6.458f);

			Assert.AreEqual(1f, randomizer.GetFloat(1));
		}

		[Test]
		public void GetInt_WhenGettingSeveralValues_InputSequenceIsPreserved()
		{
			FixedRandomizer randomizer = new FixedRandomizer(2, 9, 6);

			Assert.AreEqual(2, randomizer.GetFloat(100));
			Assert.AreEqual(9, randomizer.GetFloat(100));
			Assert.AreEqual(6, randomizer.GetFloat(100));
		}

		[Test]
		public void GetInt_WhenGettingValuesBeyondSequenceLength_RestartSequence()
		{
			FixedRandomizer randomizer = new FixedRandomizer(2, 9, 6);

			Assert.AreEqual(2, randomizer.GetFloat(100));
			Assert.AreEqual(9, randomizer.GetFloat(100));
			Assert.AreEqual(6, randomizer.GetFloat(100));
			Assert.AreEqual(2, randomizer.GetFloat(100));
		}

		[Test]
		public void GetInt_WhenGettingValueHigherThanMax_ReturnMax()
		{
			FixedRandomizer randomizer = new FixedRandomizer(2, 9, 6);

			Assert.AreEqual(1f, randomizer.GetFloat(1));
		}
	}
}
