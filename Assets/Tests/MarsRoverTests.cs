using System;
using System.Collections;
using MarsRoverDomain;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests
{
	public class MarsRoverTests
	{
		[Test]
		[TestCase("5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 5)]
		[TestCase("3 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 3)]
		[TestCase("6 2\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 6)]
		[TestCase("100 50\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 100)]
		public void Plateau_width_is_set_up_correctly_when_building(string input, int expectedWidth)
		{
			// act
			var plateau = new MarsRoverBuilder(input).Build();
			
			// assert
			Assert.AreEqual(expectedWidth, plateau.Width);
		}

		[Test]
		[TestCase("5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 5)]
		[TestCase("5 1\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 1)]
		[TestCase("1 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 5)]
		[TestCase("1000 20\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 20)]
		[TestCase("1 200\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM", 200)]
		public void Plateau_height_is_set_up_correctly_when_building(string input, int expectedHeight)
		{
			// act
			var plateau = new MarsRoverBuilder(input).Build();
			
			// assert
			Assert.AreEqual(expectedHeight, plateau.Height);
		}

		[Test]
		[TestCase("5 5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM")]
		[TestCase("55\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM")]
		[TestCase("a b\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM")]
		public void Plateau_throws_on_invalid_build(string input)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				var plateau = new MarsRoverBuilder(input).Build();
			});
		}

		// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
		// `yield return null;` to skip a frame.
		[UnityTest]
		public IEnumerator MarsRoverTestsWithEnumeratorPasses()
		{
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			yield return null;
		}
	}
}