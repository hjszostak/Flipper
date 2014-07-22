using UnityEngine;
using System.Collections;

public class MouseHandler : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = transform.parent.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float size = gameController.gameSize;	//width of the game board

		Vector3 topLeft = gameController.transform.position + new Vector3 (-size / 2, size / 2, 0);
		mousePosition -= topLeft;	//relative position to corner
		mousePosition *= gameController.getLevel() / size;	//find what square the mouse is in
		gameController.buttonClick(Mathf.FloorToInt(mousePosition.x), - Mathf.CeilToInt(mousePosition.y));
	}
}
