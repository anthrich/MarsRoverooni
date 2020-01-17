using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRoverDomain
{
	public class Rover
	{
		public Position Position { get; private set; }
		public IEnumerable<Command> Commands { get; }

		internal Rover(Position position, IEnumerable<Command> commands)
		{
			Position = position;
			Commands = commands ?? new List<Command>();
		}

		internal void ExecuteCommands()
		{
			foreach (var command in Commands)
			{
				command.Execute(this, null);
			}
		}

		public abstract class Command
		{
			internal abstract void Execute(Rover rover, Plateau plateau);

			protected void SetNewPosition(Rover rover, Position position)
			{
				rover.Position = position;
			}
		}
	}
}