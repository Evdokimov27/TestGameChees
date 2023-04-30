using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject figure;
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private List<int> point;
    [SerializeField] private List<int> cellX;
    [SerializeField] private List<int> cellY;
    [SerializeField] private GameObject[] block;
    [SerializeField] private List<GameObject> win_level;
    [SerializeField] public int for_win;
    [SerializeField] List<Vector2Int> possibleMoves;
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < block.Length; i++)
		{
			if(block[i].GetComponent<Table>().win)
			this.win_level.Add(block[i]);
		}
		for_win = this.win_level.Count;

	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0))
		{
			
			if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity) && raycastHit.transform.gameObject.tag == "Pieces")
			{
				figure.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
			}
			if (raycastHit.transform.gameObject.tag == "Block")
			{
				figure.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
			}
		}

		if (for_win == 0)
		{

			Debug.Log("Победа нахуй блээээ");
		}
		if (cellX.Count == 0 || cellY.Count == 0)
		{
			int cellsDistance = 1;//Растояние между клетками 
			point.Add(x);
			point.Add(y);
			int t = 1 * cellsDistance;
			int b = 2 * cellsDistance;


			for (int j = 0; j < 2; j++)
			{
				cellX.Add(x + b); // есть ли там клетка, если есть красим 
				cellY.Add(y + t); // есть ли там клетка, если есть красим
				cellY.Add(y + b);
				cellX.Add(x + t);
				t = -t;
			}

			t = 1 * cellsDistance;
			for (int j = 0; j < 2; j++)
			{
				cellX.Add(x - b);
				cellY.Add(y + t);
				cellY.Add(y - b);
				cellX.Add(x + t);
				t = -t;
			}
		}

		for (int i = 0; i < block.Length; i++)
		{
			for (int j = 0; i < cellX.Count; i++)
			{
				if (block[i].GetComponent<Table>().x == cellX[j])
				{
					if (block[i].GetComponent<Table>().y == cellY[j])
					{
						Debug.Log(cellX[j] + " " + cellY[j]);
					}
				}
			}
		}
    }
}
