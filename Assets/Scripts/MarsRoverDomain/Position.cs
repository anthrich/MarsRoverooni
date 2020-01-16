namespace MarsRoverDomain
{
	public class Position
	{
		public int X { get; }
		public int Y { get; }
		public Facing CurrentFacing { get; }
		
		public Position(int x, int y, Facing facing)
		{
			X = x;
			Y = y;
			CurrentFacing = facing;
		}

		public override bool Equals(object obj)
		{
			return obj is Position otherPos && Equals(otherPos);
		}

		protected bool Equals(Position other)
		{
			return X == other.X && Y == other.Y && CurrentFacing == other.CurrentFacing;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = X;
				hashCode = (hashCode * 397) ^ Y;
				hashCode = (hashCode * 397) ^ (int) CurrentFacing;
				return hashCode;
			}
		}

		public enum Facing
		{
			N = 'N',
			E = 'E',
			S = 'S',
			W = 'W'
		}
	}
}