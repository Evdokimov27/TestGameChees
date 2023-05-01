using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	[SerializeField] public bool win;
	[SerializeField] public bool canMove;
	[SerializeField] public GameObject figure;
	[SerializeField] public GameObject winManager;
	[SerializeField] public int x;
	[SerializeField] public int y;
	// Start is called before the first frame update
	void Start()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		figure = collision.gameObject;
		Debug.Log("entert");
		if (figure != null)
		{
			figure.GetComponent<GameManager>().x = x;
			figure.GetComponent<GameManager>().y = y;
			if (win)
			{
				winManager.GetComponent<Win>().for_win -= 1;
			}
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		figure = null;
		if (win)
		{
				winManager.GetComponent<Win>().for_win += 1;

		}
	}
	// Update is called once per frame
	void Update()
	{
		
	}







}
