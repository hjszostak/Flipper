﻿using UnityEngine;
using System.Collections;
using System;

public class GUIScript : MonoBehaviour {

	private GameController gameController;
	private GameObject[,] squares;
	private float deltaSize, size;
	private Vector3 bottomLeft;	//bottom left of the game background
	private GameObject piece;
	private int level;
	private float height, width;

	//Positions and styles for text
	private Rect posLevelText;
	private Rect posClickText;
	private Rect posResetButtonText;
	public GUIStyle style;
	public Texture2D[] textures;

	// Use this for initialization
	void Start () {
		//pull game data
		gameController = transform.parent.GetComponent<GameController>();
		level = gameController.startLevel;
		size = gameController.gameSize;
		bottomLeft = gameController.gameBackground.transform.position - new Vector3 (size / 2, size / 2, 0);
		piece = GameObject.Find ("Piece");
		height = Screen.height / 324.0f;
		width = Screen.width / 576.0f;

		posLevelText = new Rect (288f * width, 32.1f * height, 0, 0);
		posClickText = new Rect (490.82f * width, 286.31f * height, 0, 0);
		Vector3 tempPosition = gameController.resetButton.transform.position;
		tempPosition = Camera.main.WorldToScreenPoint (tempPosition);
		posResetButtonText = new Rect (tempPosition.x, Screen.height - tempPosition.y, 0, 0);

		Setup(level);
	}

	//Create a new level
	void Setup (int level) {
		squares = new GameObject[level, level];
		deltaSize = gameController.gameSize / level;	//width of each square
		GameObject curObject;
		Vector3 pos;
		for (int i = 0; i < level; i++) {
			for (int j = 0; j < level; j++) {
				//locate the position of the square
				pos = bottomLeft + new Vector3(deltaSize / 2 + j * deltaSize, deltaSize / 2 + i * deltaSize, 0);
				pos.z = -2;	//bring to the foreground

				//create the square and change colour
				curObject = (GameObject)Instantiate(piece, pos , Quaternion.identity);
				curObject.renderer.material.mainTexture = textures[0];

				//resize and move square to show spacing
				curObject.transform.localScale = new Vector3(deltaSize - gameController.spacing / level, deltaSize - gameController.spacing / level, 0);

				squares[j,i] = curObject;	//store the square in the 2d array
			}
		}
	}

	//Update the colour of the square
	public void UpdateSquare(int x, int y) {
		int value = Convert.ToInt32(gameController.getValues () [x, y]);
		squares[x,y].renderer.material.mainTexture = textures[value];
	}

	//Change the level
	public void ChangeBoard(int newLevel) {
		//delete old board
		for (int i = 0; i < level; i++) {
			for (int j = 0; j < level; j++) {
				Destroy(squares[j,i]);
			}
		}

		//create new board
		level = newLevel;
		Setup (newLevel);
	}

	void OnGUI() {
		GUI.Label (posLevelText, "Level: " + level.ToString(), style);
		GUI.Label (posClickText, "Flips: " + gameController.getNumClicks().ToString(), style);
		GUI.Label (posResetButtonText, "RESET", style);
	}
}
