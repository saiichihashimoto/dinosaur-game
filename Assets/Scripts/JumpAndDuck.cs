using UnityEngine;
using System.Collections;

public class JumpAndDuck : MonoBehaviour {
	public Level level = null;
	public GameObject ground = null;
	public Collider2D standingCollider = null;
	public Collider2D duckingCollider = null;
	public AudioSource jumpAudioSource = null;
	public AudioClip jumpAudioClip = null;
	private Animator animator;
	private bool grounded = true;
	private bool ducking = false;
	private float jumpVelocity = 0f;
	private float gravity = 2.4f;
	private Vector3 startVector;

	void Start() {
		animator = GetComponent<Animator>();
		standingCollider.enabled = true;
		duckingCollider.enabled = false;
	}

	void Update() {
		if (grounded) {
			if (Input.GetButton("Jump") || Input.GetAxis("Vertical") > 0) {
				jump();
			} else if (Input.GetAxis("Vertical") < 0) {
				duck();
			} else {
				stand();
			}
		} else {
			transform.position += jumpVelocity * Vector3.up * Time.deltaTime;
			jumpVelocity -= gravity;

			if (transform.position.y < ground.transform.position.y) {
				grounded = true;
				transform.position = startVector;
				animator.SetBool("jumping", false);
			} else if (3 < transform.position.y && 20 < jumpVelocity) {
				jumpVelocity = 20;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject == ground) {
			grounded = true;
			transform.position = startVector;
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
		startVector = transform.position;
		jumpVelocity = 40f + level.mainSpeed / 10f;
		grounded = false;
		animator.SetBool("jumping", true);

	}

	void duck() {
		if (ducking || !grounded) {
			return;
		}

		standingCollider.enabled = false;
		duckingCollider.enabled = true;
		ducking = true;
		animator.SetBool("ducking", true);
	}

	void stand() {
		if (!ducking) {
			return;
		}

		standingCollider.enabled = true;
		duckingCollider.enabled = false;
		ducking = false;
		animator.SetBool("ducking", false);
	}
}
