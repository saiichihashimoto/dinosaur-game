using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class SwapColorsAtNight : MonoBehaviour {
	public ColorCorrectionCurves curves = null;
	public TimeOfDay timeOfDay = null;

	void Start () {
		UpdateColors();
	}
	
	void Update () {
		UpdateColors();
	}

	void UpdateColors() {
		float currentPhase = timeOfDay.value();
		curves.redChannel.MoveKey(0, new Keyframe(0, currentPhase));
		curves.redChannel.MoveKey(1, new Keyframe(1, 1 - currentPhase));
		curves.greenChannel.MoveKey(0, new Keyframe(0, currentPhase));
		curves.greenChannel.MoveKey(1, new Keyframe(1, 1 - currentPhase));
		curves.blueChannel.MoveKey(0, new Keyframe(0, currentPhase));
		curves.blueChannel.MoveKey(1, new Keyframe(1, 1 - currentPhase));
	}
}
