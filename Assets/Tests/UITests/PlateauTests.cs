using System.Collections;
using NUnit.Framework;
using UI;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.UITests
{
	public class PlateauTests
	{
		[UnityTest]
		public IEnumerator Plateaus_create_the_plateau_cells()
		{
			// arrange
			var gameObject = new GameObject("plateau");
			var plateau = gameObject.AddComponent<Plateau>();
			var cellPrefab = new GameObject("plateauCellPrefab");
			cellPrefab.AddComponent<PlateauCell>();
			plateau.PlateauCellPrefab = cellPrefab;
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			var cells = gameObject.GetComponentsInChildren(typeof(PlateauCell));
			Assert.AreEqual(plateau.GeneratedPlateau.Height * plateau.GeneratedPlateau.Width, cells.Length);
		}
	}
}