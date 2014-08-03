using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Color backgroundColor, backgroundSquare;
	public float gameSize, spacing;
	public GameObject gameBackground, piece, guiController, resetButton;
	public int startLevel;

	private GUIScript guiScript;

	private int numClicks;
	public int level;
	private bool[,] values;

	// Use this for initialization
	void Start () {
		gameBackground = GameObject.Find ("Game Background");
		piece = GameObject.Find ("Piece");
		guiController = GameObject.Find ("GUI Controller");
		resetButton = GameObject.Find ("Reset Button");
		guiScript = guiController.GetComponent<GUIScript> ();

		level = startLevel; // DEBUG
		numClicks = 0;

		values = new bool[level,level];

		//set colours and resize game background
		Camera.main.backgroundColor = backgroundColor;
		gameBackground.renderer.material.color = backgroundSquare;
		resetButton.renderer.material.color = backgroundSquare;
		gameBackground.transform.localScale = new Vector3 (gameSize, gameSize, 1);
	}

	public void buttonClick(int x, int y) {
		//clicked block
		values [x, y] = ! values [x, y];
		guiScript.UpdateSquare (x, y);

		//left block
		if (x - 1 >= 0) {
			values [x - 1, y] = ! values [x - 1, y];
			guiScript.UpdateSquare(x-1,y);
		}

		//right block
		if (x + 1 < level) {
			values[x+1,y] = !values[x+1,y];
			guiScript.UpdateSquare(x+1,y);
		}

		//top block
		if (y - 1 >= 0) {
			values[x, y-1] = ! values[x,y-1];
			guiScript.UpdateSquare(x,y-1);
		}

		//bottom block
		if (y + 1 < level) {
			values[x,y+1] = !values[x,y+1];
			guiScript.UpdateSquare(x,y+1);
		}

		numClicks++;

		if (isComplete()) {
			newLevel();
		}
	}

	public int getLevel (){
		return level;
	}

	public bool[,] getValues() {
		return values;
	}

	public int getNumClicks() {
		return numClicks;
	}

	//checks to see if the game is complete
	private bool isComplete() {
		for (int i = 0; i < level; i++) {
			for (int j = 0; j < level; j++) {
				if (!values[j,i])
					return false;
			}
		}
		return true;
	}

	//update variables and call changeboard
	private void newLevel() {
		level++;
		values = new bool[level, level];
		guiScript.ChangeBoard (level);
	}

	public void reset() {
		level = startLevel;
		values = new bool[level,level];
		guiScript.ChangeBoard(level);
		numClicks = 0;
	}
}
