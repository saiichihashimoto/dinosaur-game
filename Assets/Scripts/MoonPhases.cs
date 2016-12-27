using UnityEngine;
using System.Collections;

public class MoonPhases : MonoBehaviour {
	public TimeOfDay timeOfDay = null;
	public SpriteRenderer renderer = null;
	public Sprite[] sprites = null;
	private int phase = 0;
	private bool isNight = false;

	void Start() {
		if (sprites.Length > 0) {
			phase = sprites.Length - 1;
			renderer.sprite = sprites[phase];
		}
	}

	void Update() {
		if (sprites.Length > 0) {
			if (!isNight && timeOfDay.isNight()) {
				phase = (phase + 1) % sprites.Length;
				renderer.sprite = sprites[phase];
			}
		}
		isNight = timeOfDay.isNight();
		renderer.color = new Color(0.7333333333f, 0.7333333333f, 0.7333333333f, timeOfDay.value());
	}
}
