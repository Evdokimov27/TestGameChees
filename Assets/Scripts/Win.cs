using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	[SerializeField] private List<GameObject> win_level;
	[SerializeField] public int for_win;
	[SerializeField] public GameObject[] light;
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
			for (int i = 0; i < light.Length; i++)
			{
				light[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.white, Color.blue, Mathf.Abs(Mathf.Sin(Time.time)));
			}
			//SceneManager.LoadScene(0);
		}
		else
		{
			for (int i = 0; i < light.Length; i++)
			{
				light[i].GetComponent<MeshRenderer>().material.color = new Color(0, 121, 204, 255);
			}
		}
	}
}
