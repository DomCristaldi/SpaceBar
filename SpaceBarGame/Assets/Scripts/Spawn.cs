using UnityEngine;
//using System;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	
	public List<GameObject> spawnPoints;
	public List<GameObject> customers;
	public List<GameObject> food;
	public List<bool>seats; //should be same size as spawn points .. keeps track of what seats are open

	int count = 0;

	//gametime
	float timeLeft = 60;
	float spawntimer;

	void Start(){
		spawntimer = timeLeft;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			spawn ();
		}
		//spawn customer every 5 secs
		timeLeft -= Time.deltaTime;
		if (spawntimer - timeLeft > 5 && spawntimer > 0) {
			spawn ();
			spawntimer = timeLeft;
		}
	}

	void spawn(){
		count ++;
		if (count > 11)
			return;
		int c = Random.Range (0,customers.Count);
		int s = Random.Range(0,spawnPoints.Count);
		while (seats[s] == true) {
			s = Random.Range(0,spawnPoints.Count);
		}
		int f = Random.Range (0,food.Count);
		GameObject tmp = customers[c];
		tmp.GetComponent<Customer>().food = food[f];
        tmp.GetComponent<Customer>().perferedFood = food[f].GetComponent<FoodType>().thisFoodType;
        //System.Array values = System.Enum.GetValues(typeof(FoodType.spaceFoodType));
        //tmp.GetComponent<Customer>().perferedFood = (FoodType.spaceFoodType)values.GetValue(UnityEngine.Random.Range(0, values.Length));

		Instantiate(tmp,spawnPoints[s].transform.position,Quaternion.identity);
		seats [s] = true;
	}
}
