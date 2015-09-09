using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

    public static ScoreHandler singleton;

    public Text uiScoreSlot;

    public int score = 0;

    void Awake() {
        if (singleton == null) {
            singleton = this;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        uiScoreSlot.text = score.ToString();
	}

    public void AddTip(int amount) {
        score += amount;
    }
}
