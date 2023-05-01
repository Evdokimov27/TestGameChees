using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	[SerializeField] private List<GameObject> win_level;
	[SerializeField] public int for_win;
	[SerializeField] private GameObject[] block;

	void Start()
    {
		for (int i = 0; i < block.Length; i++)
		{
			if (block[i].GetComponent<Table>().win)
				this.win_level.Add(block[i]);
		}
		for_win = win_level.Count;

	}

    // Update is called once per frame
    void Update()
    {
		if(for_win== 0)
		{
			SceneManager.LoadScene(0);
		}
	}
}
