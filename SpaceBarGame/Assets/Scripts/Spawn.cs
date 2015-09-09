using UnityEngine;
//using System;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public static Spawn singleton;

	public List<GameObject> spawnPoints;
	public List<GameObject> customers;
	public List<GameObject> food;
	public List<bool>seats; //should be same size as spawn points .. keeps track of what seats are open

	int count = 0;

	//gametime
	float timeLeft = 60;
	float spawntimer;

	void Awake() {
		if (singleton == null) {
			singleton = this;
		}
	}

	void Start(){
		spawntimer = timeLeft;
		seats = new List<bool>();
		for (int i = 0; i < spawnPoints.Count; i++) {
			seats.Add(false);
		}
	}

	// Update is called once per frame
	void Update () {
		//***DEBUG***
		/*
		if (Input.GetMouseButtonDown (0)) {
			spawn ();
		}
		*/
		//spawn customer every 5 secs
		timeLeft -= Time.deltaTime;
		if (spawntimer - timeLeft > 5 && spawntimer > 0) {
			spawn ();
			timeLeft = spawntimer;
		}
	}

	void spawn(){
		count ++;
		if (count >= 30)
			return;
		int c = Random.Range(0,customers.Count);
		int s = Random.Range(0,spawnPoints.Count);
		int failsafe = 0;
		while (seats[s] == true) {
			failsafe++;
			s = Random.Range(0,spawnPoints.Count);
			if (failsafe >= 60) {
				break;
			}
		}
		if (failsafe < 60) {
			int f = Random.Range (0,food.Count);
			GameObject tmp = customers[c];
			tmp.GetComponent<Customer>().food = food[f];
			tmp.GetComponent<Customer>().seatIndex = s;
	        tmp.GetComponent<Customer>().perferedFood = food[f].GetComponent<FoodType>().thisFoodType;
	        //System.Array values = System.Enum.GetValues(typeof(FoodType.spaceFoodType));
	        //tmp.GetComponent<Customer>().perferedFood = (FoodType.spaceFoodType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

			Instantiate(tmp,spawnPoints[s].transform.position,Quaternion.identity);
			seats [s] = true;
		}
	}

	public void freeSeat (int index) {
		seats[index] = false;
	}
}
