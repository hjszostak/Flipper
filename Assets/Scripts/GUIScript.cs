using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	private GameController gameController;
	private GameObject[,] squares;
	private float deltaSize, size;
	private Vector3 topLeft;
	private GameObject piece;
	public int startLevel; //DEBUG

	// Use this for initialization
	void Start () {
		gameController = transform.parent.GetComponent<GameController>();
		size = gameController.gameSize;
		topLeft = gameController.transform.position + new Vector3 (-size / 2, size / 2, 0);
		Debug.Log (topLeft);
		piece = GameObject.Find ("Piece");
		Setup(startLevel);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log(Input.mousePosition);
		}
	}

	void Setup (int level) {
		squares = new GameObject[level, level];
		deltaSize = gameController.gameSize / level;
		GameObject curObject;
		Vector3 pos;
		for (int i = 0; i < level; i++) {
			for (int j = 0; j < level; j++) {
				pos = topLeft + new Vector3(deltaSize / 2 + j * deltaSize, -deltaSize / 2 - i * deltaSize, 0);
				pos.z = -2;
				curObject = (GameObject)Instantiate(piece, pos , Quaternion.identity);
				curObject.renderer.material.color = gameController.colorOff;
				curObject.transform.localScale += new Vector3(deltaSize - gameController.spacing, deltaSize - gameController.spacing, 0);
			}
		}
	}
}
