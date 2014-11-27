using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	// speed to be modified in the inspector
	public float speed = 4.0f;

	void Start() {
		// give the ball some initial movement direction
		rigidbody2D.velocity = Vector2.one.normalized * speed;
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
		// 1 (at the top of the racket) 
		// 0 (at the middle of the racket)
		// -1 (at the bottom of the racket)
		return (ballPos.y - racketPos.y) / racketHeight;
		// we subtract the racketPos.y from the ballPos.y to have a relative position
	}

	void OnCollisionEnter2D(Collision2D col) {
		// this function is called whenever the ball
		// collides with something

		if (col.gameObject.name == "RacketLeft") { // hit the left racket
			// calculate hit factor
			float y = hitFactor(transform.position, col.transform.position, ((BoxCollider2D)col.collider).size.y);

			// calculate direction, set length to 1
			Vector2 dir = new Vector2(1, y).normalized;

			// set veolicty with dir * speed
			rigidbody2D.velocity = dir * speed;
		}

		if (col.gameObject.name == "RacketRight") { // hit the right racket
			float y = hitFactor(transform.position, col.transform.position, ((BoxCollider2D)col.collider).size.y);

			// calculate direction, set length to 1
			Vector2 dir = new Vector2(-1, y).normalized;

			// set veolicty with dir * speed
			rigidbody2D.velocity = dir * speed;
		}
	}
}
