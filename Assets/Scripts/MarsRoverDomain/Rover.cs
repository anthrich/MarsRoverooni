using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverDomain
{
	public class Rover
	{
		public Position Position { get; private set; }
		public IEnumerable<Command> Commands { get; }
		private int _executedCommandCount;

		internal Rover(Position position, IEnumerable<Command> commands)
		{
			Position = position;
			Commands = commands ?? new List<Command>();
		}

		internal bool ExecuteCommands(int number = 0)
		{
			if (number < 1) number = Commands.Count() - _executedCommandCount;
			for (int i = 0; i < number; i++)
			{
				Commands.ElementAt(_executedCommandCount + i).Execute(this, null);
				_executedCommandCount += 1;
			}

			return Commands.Count() == _executedCommandCount;
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