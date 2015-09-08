﻿using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

	public GameObject food;
	public string foodName;
	public GameObject bar;

	int tip;
	float timer;
	float orig;

	void Start(){
		//instantiate food here?
		bar = GameObject.FindGameObjectWithTag ("Bar");
		Vector3 foodSpawn = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		//Instantiate (food, transform.position, Quaternion.identity);
		foodName = food.name;
		bar.GetComponent<Barfood> ().order (food);

		tip = 20;
		timer = 3000;
		orig = 3000;
	}
	
	// Update is called once per frame
	void Update () {
		//every 5 secs, tip goes down by 1
		timer -= Time.deltaTime;
		if (orig - timer > 5) {
			tip-=1;
			orig = timer;
			Debug.Log (tip);
		}
	}
}
