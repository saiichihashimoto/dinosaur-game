using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour {
	public float lengthOfDay = 100f;
	public float lengthOfNight = 100f;
	public float fadePerSecond = 1f;
	private bool dayTime = true;
	private float timeOfDay = 0;

	void Start () {
		StartCoroutine(ChangeDayTime(lengthOfDay, false));
	}

	void Update () {
		if (timeOfDay > 0 && dayTime) {
			timeOfDay = Mathf.Max(0, timeOfDay - fadePerSecond * Time.deltaTime);
		} else if (timeOfDay < 1 && !dayTime) {
			timeOfDay = Mathf.Min(1, timeOfDay + fadePerSecond * Time.deltaTime);
		}
	}

	public float value() {
		return timeOfDay;
	}

	public bool isDay() {
		return dayTime;
	}

	public bool isNight() {
		return !dayTime;
	}

	IEnumerator ChangeDayTime(float lengthToWait, bool newDayTime) {
		yield return new WaitForSeconds(lengthToWait);
		dayTime = newDayTime;
		StartCoroutine(ChangeDayTime(newDayTime ? lengthOfDay : lengthOfNight, !newDayTime));
	}
}
