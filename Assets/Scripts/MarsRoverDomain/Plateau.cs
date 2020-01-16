using System;

namespace MarsRoverDomain
{
	public class Plateau
	{
		public int Width { get; }
		public int Height { get; }
		
		internal Plateau(int width, int height)
		{
			Width = width;
			Height = height;
		}
	}
}