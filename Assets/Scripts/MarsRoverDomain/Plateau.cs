using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRoverDomain
{
	public class Plateau
	{
		public int Width { get; }
		public int Height { get; }
		
		public IEnumerable<Rover> Rovers { get; }
		
		internal Plateau(int width, int height, IEnumerable<Rover> rovers)
		{
			Width = width;
			Height = height;
			Rovers = rovers ?? new List<Rover>();
		}

		public void Simulate()
		{
			foreach (var rover in Rovers)
			{
				rover.ExecuteCommands();
			}
		}
	}
}