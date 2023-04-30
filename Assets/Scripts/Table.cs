using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	[SerializeField] public bool win;
	[SerializeField] public GameObject figure;
	[SerializeField] private GameObject gameManager;
	[SerializeField] private int x;
	[SerializeField] private int y;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		figure = collision.gameObject;
		if (win)
		{
			gameManager.gameObject.GetComponent<GameManager>().for_win -= 1;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		figure = null;
		if (win)
		{
			gameManager.gameObject.GetComponent<GameManager>().for_win += 1;//sdadsas
		}
	}
	// Update is called once per frame
	void Update()
	{

	}
}
