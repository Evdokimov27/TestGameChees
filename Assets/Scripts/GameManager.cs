using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera camera;
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
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
			RaycastHit raycastHit;

			if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity) && raycastHit.transform.gameObject.tag == "Block")
			{
				raycastHit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
			}
        }
		if (for_win == 0)
		{

			Debug.Log("Победа нахуй блээээ"); 
		}
	}
}
