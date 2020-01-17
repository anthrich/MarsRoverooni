using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRoverDomain.RoverCommands;

namespace MarsRoverDomain
{
	public class MarsRoverBuilder
	{
		private readonly string[] _inputLines;
		public MarsRoverBuilder(string input)
		{
			_inputLines = input.Split(new string[] {"\n\n"}, StringSplitOptions.None);
		}

		public Plateau Build()
		{
			var numbers = _inputLines[0].Split(' ');
			if (numbers.Length != 2) throw new ArgumentException("Plateau size requires 2 numbers");
			if (!int.TryParse(numbers[0], out var width) || !int.TryParse(numbers[1], out var height))
			{
				throw new ArgumentException("Plateau size requires 2 numbers");
			}
			return new Plateau(width, height, BuildRovers());
		}

		private Rover BuildRover(string firstLine, string secondLine)
		{
			var positionValues = firstLine.Split(' ');
			int.TryParse(positionValues[0], out var x);
			int.TryParse(positionValues[1], out var y);
			Enum.TryParse(positionValues[2], out Position.Facing facing);
			
			
			return new Rover(new Position(x, y, facing), BuildCommands(secondLine));
		}

		private IEnumerable<Rover.Command> BuildCommands(string commandLine)
		{
			var commands = commandLine.Where(c => c.Equals('L') || c.Equals('R') || c.Equals('M'));
			foreach (var command in commands)
			{
				switch (command)
				{
					case 'L':
						yield return new TurnLeftCommand();
						break;
					case 'R':
						yield return new TurnRightCommand();
						break;
					case 'M':
						yield return new MoveCommand();
						break;
				}
			}
		}

		private List<Rover> BuildRovers()
		{
			var rovers = new List<Rover>();
			
			for (var i = 1; i < _inputLines.Length; i += 2)
			{
				rovers.Add(BuildRover(_inputLines[i], _inputLines[i+1]));
			}

			return rovers;
		}
	}
}