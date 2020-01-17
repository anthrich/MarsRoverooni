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
			for (int x = 0; x < GeneratedPlateau.Width; x++)
			{
				for (int y = 0; y < GeneratedPlateau.Height; y++)
				{
					var cell = Instantiate(PlateauCellPrefab, transform);
					cell.transform.position = new Vector3(x * 14, y * 14);
				}
			}
		}
	}
}