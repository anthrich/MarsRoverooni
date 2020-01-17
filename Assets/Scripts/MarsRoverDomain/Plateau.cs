using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverDomain
{
	public class Plateau
	{
		public int Width { get; }
		public int Height { get; }
		
		public int CurrentSimulationStep { get; private set; }

		private readonly List<Rover> _simulatedRovers;
		
		public IEnumerable<Rover> Rovers { get; }
		
		internal Plateau(int width, int height, IEnumerable<Rover> rovers)
		{
			Width = width;
			Height = height;
			Rovers = rovers ?? new List<Rover>();
			_simulatedRovers = new List<Rover>();
		}

		public bool Simulate(int steps = 0)
		{
			
			if (steps < 1) steps = Rovers.Select(r => r.Commands.Count()).Aggregate((agg, val) => agg + val);
			for (int i = 0; i < steps; i++)
			{
				if(_simulatedRovers.Count() == Rovers.Count()) return false;
				var rover = Rovers.Except(_simulatedRovers).First();
				var roverCompleted = rover.ExecuteCommands(1);
				if(roverCompleted) _simulatedRovers.Add(rover);
				CurrentSimulationStep = CurrentSimulationStep + 1;
			}

			return true;
		}
	}
}