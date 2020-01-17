using MarsRoverDomain;
using UnityEngine;

namespace UI
{
	public class Plateau : MonoBehaviour
	{
		public GameObject PlateauCellPrefab;
		public GameObject RoverPrefab;
		public MarsRoverDomain.Plateau GeneratedPlateau;
		
		public void Start()
		{
			GeneratedPlateau = new MarsRoverBuilder("5 5\n\n1 2 N\n\nLMLMLMLMM\n\n3 3 E\n\nMMRMMRMRRM").Build();
			PopulatePlateauCells();
			PopulateRovers();
		}

		private void PopulatePlateauCells()
		{
			for (int x = 0; x < GeneratedPlateau.Width; x++)
			{
				for (int y = 0; y < GeneratedPlateau.Height; y++)
				{
					var cell = Instantiate(PlateauCellPrefab, transform);
					var plateauCell = cell.GetComponent<PlateauCell>();
					plateauCell.RowPosition = x;
					plateauCell.ColumnPosition = y;
				}
			}
		}

		private void PopulateRovers()
		{
			foreach (var roverModel in GeneratedPlateau.Rovers)
			{
				var roverObject = Instantiate(RoverPrefab, transform);
				var rover = roverObject.GetComponent<Rover>();
				rover.RoverModel = roverModel;
			}
		}
	}
}