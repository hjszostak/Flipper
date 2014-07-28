using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Color backgroundColor, colorOn, colorOff, backgroundSquare;
	public float gameSize, spacing;
	public GameObject gameBackground, piece, guiController;
	public int startLevel;

	private GUIScript guiScript;

	public int numClicks;
	public int level;
	private bool[,] values;

	// Use this for initialization
	void Start () {
		gameBackground = GameObject.Find ("Game Background");

		level = startLevel; // DEBUG
		numClicks = 0;

		piece = GameObject.Find ("Piece");
		guiController = GameObject.Find ("GUI Controller");
		guiScript = guiController.GetComponent<GUIScript> ();

		values = new bool[level,level];

		Camera.main.backgroundColor = backgroundColor;
		gameBackground.renderer.material.color = backgroundSquare;
		gameBackground.transform.localScale = new Vector3 (gameSize, gameSize, 1);
	}
	
	// Update is called once per frame
	void Update () {

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
}
