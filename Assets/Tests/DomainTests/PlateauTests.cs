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
	}
}