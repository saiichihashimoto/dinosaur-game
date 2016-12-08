using UnityEngine;
using System.Collections;

public class JumpAndDuck : MonoBehaviour {
	public GameObject ground = null;
	public AudioSource jumpAudioSource = null;
	public AudioClip jumpAudioClip = null;
	public float jumpMagnitude = 1;
	private Animator animator;
	private BoxCollider2D collider;
	private Vector2 initialColliderOffset;
	private Vector2 initialColliderSize;
	private bool grounded = true;
	private bool ducking = false;

	void Start() {
		animator = GetComponent<Animator>();
		collider = GetComponent<BoxCollider2D>();
		initialColliderOffset = collider.offset;
		initialColliderSize = collider.size;
	}

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
			animator.SetBool("jumping", false);
		}
	}


	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject == ground) {
			grounded = false;
			animator.SetBool("jumping", true);
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
		animator.SetBool("jumping", true);

	}

	void duck() {
		if (ducking || !grounded) {
			return;
		}

		collider.offset = new Vector2(1.265f, 0.625f);
		collider.size = new Vector2(2.53f, 1.25f);
		ducking = true;
		animator.SetBool("ducking", true);
	}

	void stand() {
		if (!ducking) {
			return;
		}

		collider.offset = initialColliderOffset;
		collider.size = initialColliderSize;
		ducking = false;
		animator.SetBool("ducking", false);
	}
}
