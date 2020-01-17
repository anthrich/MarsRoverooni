using System.Collections.Generic;
using System.Linq;
using MarsRoverDomain;
using NUnit.Framework;

namespace Tests.DomainTests
{
	public class PlateauTests
	{
		[Test]
		public void Simulate_runs_all_rover_commands()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			
			// act
			plateau.Simulate();
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(1, 3, Position.Facing.N),
				new Position(5, 1, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}

		[Test]
		public void Simulate_runs_1_step_when_stipulated()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			
			// act
			plateau.Simulate(1);
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(1, 2, Position.Facing.W),
				new Position(3, 3, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}
		
		[Test]
		public void Simulate_runs_steps_in_sequence_when_stipulated()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(1);
			
			// act
			plateau.Simulate(1);
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(0, 2, Position.Facing.W),
				new Position(3, 3, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}
		
		[Test]
		public void Simulate_runs_many_steps_in_sequence_when_stipulated()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(8);
			
			// act
			plateau.Simulate(1);
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(1, 3, Position.Facing.N),
				new Position(3, 3, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}
		
		[Test]
		public void Simulate_runs_many_steps_accross_rovers_in_sequence_when_stipulated()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(9);
			
			// act
			plateau.Simulate(1);
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(1, 3, Position.Facing.N),
				new Position(4, 3, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}
		
		[Test]
		public void Simulate_finishes_simulation_when_all_steps_have_been_ran_in_sequence()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(9);
			
			// act
			plateau.Simulate(10);
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(1, 3, Position.Facing.N),
				new Position(5, 1, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}
		
		[Test]
		public void Simulate_handles_overshooting_of_simulation_gracefully()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(9);
			
			// act
			plateau.Simulate(11);
			
			// assert
			var expectedPositions = new List<Position>()
			{
				new Position(1, 3, Position.Facing.N),
				new Position(5, 1, Position.Facing.E)
			};
			CollectionAssert.AreEqual(expectedPositions, plateau.Rovers.Select(r => r.Position));
		}
		
		[Test]
		public void Simulate_returns_true_while_steps_remain()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(9);
			
			// act
			var simulationComplete = plateau.Simulate(9);
			
			// assert
			Assert.IsTrue(simulationComplete);
		}
		
		[Test]
		public void Simulate_returns_false_when_no_steps_remain()
		{
			// arrange
			var input = "5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM";
			var plateau = new MarsRoverBuilder(input).Build();
			plateau.Simulate(9);
			
			// act
			var simulationComplete = plateau.Simulate(10);
			
			// assert
			Assert.IsTrue(simulationComplete);
		}
	}
}