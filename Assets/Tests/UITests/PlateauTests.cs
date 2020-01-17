using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using UI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests.UITests
{
	public class PlateauTests
	{
		private Plateau SetUpPlateau()
		{
			var gameObject = new GameObject("plateau");
			var plateau = gameObject.AddComponent<Plateau>();
			var cellPrefab = new GameObject("plateauCellPrefab");
			cellPrefab.AddComponent<PlateauCell>();
			var text = new GameObject("text").AddComponent<Text>();
			text.transform.SetParent(cellPrefab.transform);
			cellPrefab.GetComponent<PlateauCell>().Label = text;
			plateau.PlateauCellPrefab = cellPrefab;
			var roverPrefab = new GameObject("roverPrefab");
			roverPrefab.AddComponent<Rover>();
			plateau.RoverPrefab = roverPrefab;
			return plateau;
		}
		
		[UnityTest]
		public IEnumerator Plateaus_add_cells()
		{
			// arrange
			var plateau = SetUpPlateau();
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			var cells = plateau.gameObject.GetComponentsInChildren(typeof(PlateauCell)).OfType<PlateauCell>();
			Assert.AreEqual(
				(plateau.GeneratedPlateau.Width + 1) * (plateau.GeneratedPlateau.Height + 1),cells.Count());
		}

		[UnityTest]
		public IEnumerator Plateaus_position_the_cells_correctly()
		{
			// arrange
			var plateau = SetUpPlateau();
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			var cells = plateau.gameObject.GetComponentsInChildren(typeof(PlateauCell)).OfType<PlateauCell>();
			Assert.IsTrue(cells.All(c =>
				{
					var pos = c.transform.position;
					return Math.Abs(pos.x - c.RowPosition * c.Dimensions.x) < 0.1f &&
					       Math.Abs(pos.y - c.ColumnPosition * c.Dimensions.y) < 0.1f;
				}));
		}
		
		[UnityTest]
		public IEnumerator Plateaus_add_rovers()
		{
			// arrange
			var plateau = SetUpPlateau();
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			Assert.AreEqual(
				plateau.GeneratedPlateau.Rovers.Count(),
				plateau.GetComponentsInChildren(typeof(Rover)).Length);
		}
		
		[UnityTest]
		public IEnumerator Plateaus_position_rovers_correctly()
		{
			// arrange
			var plateau = SetUpPlateau();
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			var rovers = plateau.gameObject.GetComponentsInChildren(typeof(Rover)).OfType<Rover>();
			Assert.IsTrue(rovers.All(r =>
			{
				var pos = r.transform.position;
				return Math.Abs(pos.x - r.RoverModel.Position.X * r.Dimensions.x) < 0.1f &&
				       Math.Abs(pos.y - r.RoverModel.Position.Y * r.Dimensions.y) < 0.1f;
			}));
		}
		
		[UnityTest]
		public IEnumerator Plateaus_rotate_rovers_correctly()
		{
			// arrange
			var plateau = SetUpPlateau();
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			var correctRotations = new[] {90, 0, -90, -180};
			var rovers = plateau.gameObject.GetComponentsInChildren(typeof(Rover)).OfType<Rover>();
			Assert.IsTrue(rovers.All(r =>
			{
				var rotation = r.transform.eulerAngles.z;
				return Math.Abs(rotation - correctRotations[(int)r.RoverModel.Position.CurrentFacing]) < 0.1;
			}));
		}
		
		[UnityTest]
		public IEnumerator NextStep_steps_forward_in_the_simulation()
		{
			// arrange
			var plateau = SetUpPlateau();
			yield return new WaitForFixedUpdate();
			
			// act
			plateau.NextStep();
			
			// assert
			Assert.AreEqual(1, plateau.GeneratedPlateau.CurrentSimulationStep);
		}
	}
}