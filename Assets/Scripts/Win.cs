using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
	[SerializeField] private List<GameObject> win_level;
	[SerializeField] public int for_win;
	[SerializeField] private GameObject[] block;
	[SerializeField] private GameObject Mask;
	private float nextActionTime = 10f;
	public float period = 1f;
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
			if (Mask.transform.localScale.x > 0 && Mask.transform.localScale.z > 0)
			{
				Mask.transform.localScale = new Vector3(Mask.transform.localScale.x-0.15f, 0.5f, Mask.transform.localScale.z-0.15f); ;
			}
			else SceneManager.LoadScene(0);
		}
		else
		{
			if (Mask.transform.localScale.x <= 20 && Mask.transform.localScale.z <= 20)
			{
				Mask.transform.localScale = new Vector3(Mask.transform.localScale.x+0.15f, 0.5f, Mask.transform.localScale.z+0.15f); ;
			}
		}
	}

}
