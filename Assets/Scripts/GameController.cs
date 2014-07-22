using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Color backgroundColor, colorOn, colorOff, backgroundSquare;
	public float gameSize, spacing;
	public GameObject gameBackground, piece;
	public int startLevel;

	public int level;
	private bool[,] values;

	// Use this for initialization
	void Start () {
		GameObject gameBackground = GameObject.Find ("Game Background");

		level = startLevel;	//DEBUG

		piece = GameObject.Find ("Piece");

		values = new bool[1,1];
		values [0, 0] = false;

		Camera.main.backgroundColor = backgroundColor;
		gameBackground.renderer.material.color = backgroundSquare;
		gameBackground.transform.localScale = new Vector3 (gameSize, gameSize, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void buttonClick(int x, int y) {
		//Perform Action
		Debug.Log (x + ", " + y);
		}

	public int getLevel (){
		return level;
	}

	public bool[,] getValues() {
		return values;
	}
}
