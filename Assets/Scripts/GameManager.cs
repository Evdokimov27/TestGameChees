using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
		if (for_win == 0)
		{
			Debug.Log("Победа нахуй"); 
		}
	}
}
