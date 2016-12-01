using UnityEngine;
using System.Collections;

public class JumpAndDuck : MonoBehaviour {
	public GameObject ground = null;
	public AudioSource jumpAudioSource = null;
	public AudioClip jumpAudioClip = null;
	public float jumpMagnitude = 1;
	private bool grounded = true;
	private bool ducking = false;

	void Update() {
		if (!grounded) {
			return;
		}

		if (Input.GetButton("Jump")) {
			jump();
			return;
		}

		float vertical = Input.GetAxis("Vertical");

		if (vertical > 0) {
			jump();
		} else if (vertical < 0) {
			duck();
		} else {
			stand();
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject == ground) {
			grounded = true;
		}
	}


	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject == ground) {
			grounded = false;
		}
	}

	void jump() {
		if (!grounded) {
			return;
		}

		stand();
		if (jumpAudioSource && jumpAudioClip) {
			jumpAudioSource.PlayOneShot(jumpAudioClip, 1);
		}
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpMagnitude, ForceMode2D.Impulse);
		grounded = false;

	}

	void duck() {
		if (ducking || !grounded) {
			return;
		}

		transform.localScale = new Vector3(1.5f, 0.5f, 1f);
		ducking = true;
	}

	void stand() {
		if (!ducking) {
			return;
		}

		transform.localScale = new Vector3(1f, 1f, 1f);
		ducking = false;
	}
}
