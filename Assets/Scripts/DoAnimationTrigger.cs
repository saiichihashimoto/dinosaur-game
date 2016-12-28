using UnityEngine;
using System.Collections;

public class DoAnimationTrigger : MonoBehaviour {
	public string trigger = null;

	void Start () {
		GetComponent<Animator>().SetBool(trigger, true);
	}
}
