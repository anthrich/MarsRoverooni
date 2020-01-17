using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MarsRoverDomain;
using MarsRoverDomain.RoverCommands;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Vector2 = UnityEngine.Vector2;

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
		public void Invalid_builds_throw(string input)
		{
			Assert.Throws<ArgumentException>(() =>
			{
				var plateau = new MarsRoverBuilder(input).Build();
			});
		}

		[Test]
		public void Rover_initial_positions_are_set_up_on_build()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var firstRoverPosition = new Position(1 , 2, Position.Facing.N);
			
			// act
			var plateau = new MarsRoverBuilder(input).Build();
			
			// assert
			Assert.AreEqual(firstRoverPosition, plateau.Rovers.First().Position);
		}

		[Test]
		public void Multiple_rovers_will_have_their_positions_set_on_built()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM\n\n1 5 S\n\nMMRMMRMRRM";
			var secondRoverPosition = new Position(3, 3, Position.Facing.E);
			var thirdRoverPosition = new Position(1, 5, Position.Facing.S);
			var positions = new List<Position>() {secondRoverPosition, thirdRoverPosition};
			
			// act
			var plateau = new MarsRoverBuilder(input).Build();
			
			// assert
			CollectionAssert.AreEqual(plateau.Rovers.Skip(1).Select(r => r.Position).ToList(), positions);
		}

		[Test]
		public void Rovers_receive_their_commands_in_the_same_order_as_the_input()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMRM";
			var expectedCommandTypes = new List<Type>()
			{
				typeof(TurnLeftCommand),
				typeof(MoveCommand),
				typeof(TurnRightCommand),
				typeof(MoveCommand)
			};
			
			// act
			var plateau = new MarsRoverBuilder(input).Build();
			
			// assert
			var actualCommandTypes = plateau.Rovers.First().Commands.Select(c => c.GetType()).ToList();
			CollectionAssert.AreEqual(expectedCommandTypes, actualCommandTypes);
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