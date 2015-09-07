using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

	public GameObject food;
	public string foodName;
	public GameObject bar;

	int tip;

	void Start(){
		//instantiate food here?
		Vector3 foodSpawn = new Vector3 (transform.position.x, transform.position.y + 150, transform.position.z);
		Instantiate (food, transform.position, Quaternion.identity);
		foodName = food.name;
		bar.GetComponent<Barfood> ().order (food);
	}
	
	// Update is called once per frame
	void Update () {
		//time goes by, customer get less happy = lower tip
	
	}
}
