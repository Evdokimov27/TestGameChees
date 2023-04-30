using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	[SerializeField] public bool win;
	[SerializeField] public bool canMove;
	[SerializeField] public GameObject figure;
	[SerializeField] private GameObject gameManager;
	[SerializeField] public int x;
	[SerializeField] public int y;
	// Start is called before the first frame update
	void Start()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		figure = collision.gameObject;
		gameManager.GetComponent<GameManager>().x = x;
		gameManager.GetComponent<GameManager>().y = y;
		if (win)
		{
			gameManager.gameObject.GetComponent<GameManager>().for_win -= 1;
		}
	}
	private void OnCollisionStay(Collision collision)
	{

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
