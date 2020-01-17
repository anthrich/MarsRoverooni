using System.Collections;
using NUnit.Framework;
using UI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests.UITests
{
	public class PlateauCellTests
	{
		[UnityTest]
		public IEnumerator Plateau_cells_set_the_position_text()
		{
			// arrange
			var plateauCell = SetUpPlateauCell();
			plateauCell.RowPosition = 5;
			plateauCell.ColumnPosition = 4;
			
			// act
			yield return new WaitForFixedUpdate();
			
			// assert
			var text = plateauCell.GetComponentInChildren<Text>().text;
			Assert.AreEqual("5,4", text);
		}

		private PlateauCell SetUpPlateauCell()
		{
			var cellPrefab = new GameObject("plateauCellPrefab");
			var plateauCell = cellPrefab.AddComponent<PlateauCell>();
			var canvas = new GameObject("canvas");
			canvas.AddComponent<Canvas>();
			canvas.transform.SetParent(cellPrefab.transform);
			var textGameObject = new GameObject("text");
			var text = textGameObject.AddComponent<Text>();
			text.transform.SetParent(canvas.transform);
			plateauCell.Label = text;
			return plateauCell;
		}
	}
}