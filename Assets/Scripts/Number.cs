using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {
	public GameObject[] digits = new GameObject[]{ };
	public Sprite[] sprites = new Sprite[10];
	private SpriteRenderer[] digitSprites = null;
	private int val = -1;

	public int Value {
		get { return val; }
		set { 
			val = value;
			if (digitSprites != null) {
				for (int i = 0; i < digitSprites.Length; i++) {
					digitSprites[i].sprite = sprites[(int) (val / Mathf.Pow(10, i)) % 10];
				}
			}
		}
	}

	void Start() {
		digitSprites = new SpriteRenderer[digits.Length];
		for (int i = 0; i < digits.Length; i++) {
			digitSprites[i] = digits[i].GetComponent<SpriteRenderer>();
		}
		Value = 0;
	}
}
