using System;
using System.Collections.Generic;

namespace MarsRoverDomain.RoverCommands
{
	public class MoveCommand : Rover.Command
	{
		Dictionary<Position.Facing, Tuple<int, int>> Movements = new Dictionary<Position.Facing, Tuple<int, int>>()
		{
			{Position.Facing.N, new Tuple<int, int>(0, 1)},
			{Position.Facing.E, new Tuple<int, int>(1, 0)},
			{Position.Facing.S, new Tuple<int, int>(0, -1)},
			{Position.Facing.W, new Tuple<int, int>(-1, 0)}
		};

		internal override void Execute(Rover rover, Plateau plateau)
		{
			var movement = Movements[rover.Position.CurrentFacing];
			var newPosition = new Position(
				rover.Position.X + movement.Item1,
				rover.Position.Y + movement.Item2,
				rover.Position.CurrentFacing);
			SetNewPosition(rover, newPosition);
		}
	}
}