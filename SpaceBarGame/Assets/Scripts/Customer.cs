using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Customer : MonoBehaviour {

    public SpriteRenderer foodThought;

	public GameObject food;
	public string foodName;
    public FoodType.spaceFoodType perferedFood;
	public GameObject bar;

	public Collider coll;

	public Text scoreText;

	public AlienMoodController moodController;

	public int seatIndex;

	int tip;
	float timer;
	float orig;

	void Start(){
		//instantiate food here?
		bar = GameObject.FindGameObjectWithTag ("barobj");
		scoreText = GameObject.FindGameObjectWithTag ("score").GetComponent<Text>();
		//Vector3 foodSpawn = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//Instantiate (food, transform.position, Quaternion.identity);
		foodName = food.name;
		bar.GetComponent<Barfood> ().order (food);

		tip = 20;
		timer = 3000;
		orig = 3000;

        foodThought.sprite = food.GetComponent<FoodType>().foodSprite;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(food.GetComponent<FoodType>().foodSpriteRen != null);
        //foodThought.sprite = food.GetComponent<FoodType>().foodSprite.sprite;
		//every 5 secs, tip goes down by 1
		timer -= Time.deltaTime;
		if (orig - timer > 2) {
			tip-=1;
			timer = orig;
			//Debug.Log (tip);
			CheckTip();
		}
	}
	//accessed when customer is given food
	public void served(GameObject foo){
		//if (foo.name == foodName) {
        if (foo.GetComponent<FoodType>().thisFoodType == perferedFood) {
			//add to score, delete food and customer
            ScoreHandler.singleton.AddTip(tip);
			Spawn.singleton.freeSeat(seatIndex);
			Destroy(foo);
			Destroy(gameObject);
		}
		else {
			tip -= 3;
			CheckTip();
		}
	}

	void CheckTip () {
		if (tip <= 12 && tip > 5) {
			moodController.SetAnnoyed();
		}
		else if (tip <= 5 && tip > 0) {
			moodController.SetAngry();
		}
		else if (tip <= 0) {
			ScoreHandler.singleton.AddTip(-10);
			Spawn.singleton.freeSeat(seatIndex);
			Destroy(gameObject);
		}
	}
}
