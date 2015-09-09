using UnityEngine;
using System.Collections;

public enum Mood {
	happy,
	annoyed,
	angry
}

[ExecuteInEditMode]
public class AlienMoodController : MonoBehaviour {

	public Mood currentMood;
	public SpriteRenderer mouthHappy;
	public SpriteRenderer mouthAnnoyed;
	public SpriteRenderer mouthAngry;
	public SpriteRenderer stalkHappy;
	public SpriteRenderer stalkAnnoyed;
	public SpriteRenderer stalkAngry;
	
	void Start () {
		currentMood = Mood.happy;
	}

	public void SetHappy () {
		currentMood = Mood.happy;
		mouthHappy.enabled = true;
		stalkHappy.enabled = true;
		mouthAnnoyed.enabled = false;
		stalkAnnoyed.enabled = false;
		mouthAngry.enabled = false;
		stalkAngry.enabled = false;
	}

	public void SetAnnoyed () {
		currentMood = Mood.annoyed;
		mouthHappy.enabled = false;
		stalkHappy.enabled = false;
		mouthAnnoyed.enabled = true;
		stalkAnnoyed.enabled = true;
		mouthAngry.enabled = false;
		stalkAngry.enabled = false;
	}

	public void SetAngry () {
		currentMood = Mood.angry;
		mouthHappy.enabled = false;
		stalkHappy.enabled = false;
		mouthAnnoyed.enabled = false;
		stalkAnnoyed.enabled = false;
		mouthAngry.enabled = true;
		stalkAngry.enabled = true;
	}

	void Update () {
		if (currentMood == Mood.happy) {
			SetHappy();
		}
		else if (currentMood == Mood.annoyed) {
			SetAnnoyed();
		}
		else if (currentMood == Mood.angry) {
			SetAngry();
		}
	}

}
