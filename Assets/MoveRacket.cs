using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {

	// up and down keys (to be set in the inspector)
	public KeyCode up;
	public KeyCode down;
	void FixedUpdate() {
		if (Input.GetKey(up)) { // up key pressed
			transform.Translate(new Vector2(0.0f, 0.1f)); // in this case, we add nothing to the x-coordinate but we add 0.1 or -0.1
		}												  // to the y-coordinate to move the racket upwards/downwards a bit
		if (Input.GetKey (down)){ // down key pressed
			transform.Translate (new Vector3(0.0f, -0.1f));
		}
	}
}
