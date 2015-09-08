using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public List<GameObject> spawnPoints;
	public List<GameObject> customers;
	public List<GameObject> food;

	//gametime
	float timeLeft = 300;
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
		if (spawntimer - timeLeft > 5) {
			spawn ();
			spawntimer = timeLeft;
		}
	}

	void spawn(){
		int c = Random.Range (0,customers.Count);
		int s = Random.Range(0,spawnPoints.Count);
		int f = Random.Range (0,food.Count);
		GameObject tmp = customers[c];
		tmp.GetComponent<Customer>().food = food[f];
		Instantiate(tmp,spawnPoints[s].transform.position,Quaternion.identity);
	}
}
