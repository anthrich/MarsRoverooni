using System;
using System.Collections.Generic;

namespace MarsRoverDomain
{
	public class MarsRoverBuilder
	{
		private readonly string _input;
		public MarsRoverBuilder(string input)
		{
			_input = input;
		}

		public Plateau Build()
		{
			var setUpLines = _input.Split(new string[] {"\n\n"}, StringSplitOptions.None);
			var numbers = setUpLines[0].Split(' ');
			if (numbers.Length != 2) throw new ArgumentException("Plateau size requires 2 numbers");
			if (!int.TryParse(numbers[0], out var width) || !int.TryParse(numbers[1], out var height))
			{
				throw new ArgumentException("Plateau size requires 2 numbers");
			}
			return new Plateau(width, height, new List<Rover>() { BuildRover(setUpLines[1], setUpLines[2]) });
		}

		private Rover BuildRover(string firstLine, string secondLine)
		{
			var positionValues = firstLine.Split(' ');
			int.TryParse(positionValues[0], out var x);
			int.TryParse(positionValues[1], out var y);
			Enum.TryParse(positionValues[2], out Position.Facing facing);
			return new Rover(new Position(x, y, facing));
		}
	}
}