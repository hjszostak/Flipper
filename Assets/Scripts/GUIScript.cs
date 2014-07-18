using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	private GameController gameController;
	private bool[,] values;
	private Rect gameBackground;

	// Use this for initialization
	void Start () {
		gameController = transform.parent.GetComponent<GameController>();

		Vector3 origin = gameController.gameBackground.transform.position;
		float size = gameController.gameBackground.renderer.bounds.size.x;

		gameBackground = new Rect (origin.x - size / 2, origin.y + size / 2, size, size);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		int level = gameController.getLevel ();
		values = gameController.getValues ();
	}
}
