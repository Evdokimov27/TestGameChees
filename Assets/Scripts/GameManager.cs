using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private List<int> cellX;
    [SerializeField] private List<int> cellY;
	[SerializeField] public int x;
	[SerializeField] public int y;
	[SerializeField] private GameObject figure;
	[SerializeField] private GameObject[] block;
    [SerializeField] private List<GameObject> win_level;
    [SerializeField] public int for_win;
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
		foreach (Touch touch in Input.touches)
		{
			if (touch.fingerId == 0)
			{
				if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity) && raycastHit.transform.gameObject.tag == "Pieces")
				{
					raycastHit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
					cellX.RemoveRange(0, cellX.Count);
					cellY.RemoveRange(0, cellY.Count);
					int cellsDistance = 1;//Растояние между клетками 
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



					for (int i = 0; i < block.Length; i++)
					{
						for (int j = 0; j < cellX.Count; j++)
						{
							if (block[i].GetComponent<Table>().x == cellX[j] && block[i].GetComponent<Table>().y == cellY[j])
							{
								block[i].GetComponent<MeshRenderer>().material.color = new Color(4, 4, 4, 4);
								block[i].GetComponent<Table>().canMove = true;
							}
						}
					}
				}
				if (raycastHit.transform.gameObject.tag == "Block")
				{
					figure.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

					for (int i = 0; i < block.Length; i++)
					{
						block[i].GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
						figure.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

						if (raycastHit.transform.GetComponent<Table>().canMove == true)
						{
							figure.transform.position = raycastHit.transform.position;

							x = block[i].GetComponent<Table>().x;
							y = block[i].GetComponent<Table>().y;

						}
						block[i].GetComponent<Table>().canMove = false;

					}
				}
				if (raycastHit.transform.gameObject.tag != "Block" && raycastHit.transform.gameObject.tag != "Pieces")
				{
					continue;
				}
			}
		}

		if (for_win == 0)
		{
			Debug.Log("Победа нахуй блээээ");
		}
		

		
    }
}
