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
	[SerializeField] private PostProcessProfile post;
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
			if (post.GetSetting<Bloom>().intensity.value < 30)
			{
				nextActionTime += period;
				post.GetSetting<Bloom>().intensity.value += 0.5f;
			}
			else SceneManager.LoadScene(0);
		}
		else
		{
			if (post.GetSetting<Bloom>().intensity.value > 0)
			{
				nextActionTime += period;
				post.GetSetting<Bloom>().intensity.value -= 0.5f;
			}
		}
	}

}
