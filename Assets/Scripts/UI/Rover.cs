using UnityEngine;

namespace UI
{
	public class Rover : MonoBehaviour
	{
		public MarsRoverDomain.Rover RoverModel;
		public Vector3 Dimensions = new Vector3(14,14);

		private void Start()
		{
			SetRoverPosition();
		}

		private void Update()
		{
			SetRoverPosition();
		}

		private void SetRoverPosition()
		{
			if (RoverModel != null)
			{
				var transform1 = transform;
				transform1.position = new Vector3(
					RoverModel.Position.X * Dimensions.x, RoverModel.Position.Y * Dimensions.y);
				var rotationOffset = 90;
				var newRotation = -90 * (int) RoverModel.Position.CurrentFacing;
				transform1.eulerAngles = new Vector3(0,0, newRotation + rotationOffset);
			}
		}
	}
}