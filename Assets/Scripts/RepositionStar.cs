using UnityEngine;
using System.Collections;

public class RepositionStar : MonoBehaviour {
	public TimeOfDay timeOfDay = null;
	public float minimumStart = -500f;
	public float maximumStart = 500f;
	private bool isNight = false;

	void Update () {
		if (!isNight && timeOfDay.isNight()) {
			transform.position = new Vector3(minimumStart + Random.value * (maximumStart - minimumStart), 0.3333333333f + Random.value * 4.6666666667f, 0f);
			Animator animator = GetComponent<Animator>();
			AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
			animator.Play(state.fullPathHash, -1, Random.value);
		}
		isNight = timeOfDay.isNight();
	}
}
