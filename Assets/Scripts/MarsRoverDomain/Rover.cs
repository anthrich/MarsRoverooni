using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRoverDomain
{
	public class Rover
	{
		public Position Position { get; }
		public IEnumerable<Command> Commands { get; }

		internal Rover(Position position, IEnumerable<Command> commands)
		{
			Position = position;
			Commands = commands ?? new List<Command>();
		}

		public abstract class Command
		{
		}
	}
}