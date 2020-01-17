using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class PlateauCell : MonoBehaviour
	{
		public Vector3 Dimensions = new Vector3(14,14);
		public int RowPosition;
		public int ColumnPosition;
		public Text Label;
		
		void Start()
		{
			transform.position = new Vector3(RowPosition * Dimensions.x, ColumnPosition * Dimensions.y);
			Label.text = $"{RowPosition},{ColumnPosition}";
		}

		void Update()
		{
		}
	}
}