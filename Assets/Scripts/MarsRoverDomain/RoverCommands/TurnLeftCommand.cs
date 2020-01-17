using System;

namespace MarsRoverDomain.RoverCommands
{
	public class TurnLeftCommand : Rover.Command
	{
		internal override void Execute(Rover rover, Plateau plateau)
		{
			var currentFacingIndex = (int) rover.Position.CurrentFacing;
			var newFacingIndex = currentFacingIndex - 1;
			if (newFacingIndex < 0) newFacingIndex = Enum.GetValues(typeof(Position.Facing)).Length - 1;
			var newFacing = (Position.Facing) newFacingIndex;
			SetNewPosition(rover, new Position(rover.Position.X, rover.Position.Y, newFacing));
		}
	}
}