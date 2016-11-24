using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SwapColorsPeriodically : MonoBehaviour {
	public ColorCorrectionCurves curves = null;
	public float period = 100f;
	public float duration = 10f;
	private bool swapping = false;
	private bool swapped = false;
	private float swapStartedAt = 0;

	// Use this for initialization
	void Start() {
		curves.redChannel.MoveKey(0, new Keyframe(0, 0));
		curves.redChannel.MoveKey(1, new Keyframe(1, 1));
		curves.greenChannel.MoveKey(0, new Keyframe(0, 0));
		curves.greenChannel.MoveKey(1, new Keyframe(1, 1));
		curves.blueChannel.MoveKey(0, new Keyframe(0, 0));
		curves.blueChannel.MoveKey(1, new Keyframe(1, 1));
		StartCoroutine(BeginSwap(true));
	}

	// Update is called once per frame
	void Update() {
		if (!swapping) {
			return;
		}
		float val = Mathf.Lerp(0, 1, (Time.timeSinceLevelLoad - swapStartedAt) / duration);
		if (swapped) {
			val = 1 - val;
		}
		curves.redChannel.MoveKey(0, new Keyframe(0, val));
		curves.redChannel.MoveKey(1, new Keyframe(1, 1 - val));
		curves.greenChannel.MoveKey(0, new Keyframe(0, val));
		curves.greenChannel.MoveKey(1, new Keyframe(1, 1 - val));
		curves.blueChannel.MoveKey(0, new Keyframe(0, val));
		curves.blueChannel.MoveKey(1, new Keyframe(1, 1 - val));
		if (swapStartedAt + duration < Time.timeSinceLevelLoad) {
			swapping = false;
			swapped = !swapped;
		}
	}

	private IEnumerator BeginSwap(bool dontSwap) {
		if (!dontSwap) {
			swapping = true;
			swapStartedAt = Time.timeSinceLevelLoad;
		}
		yield return new WaitForSeconds(period);
		StartCoroutine(BeginSwap(false));
	}
}