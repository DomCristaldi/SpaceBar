using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barfood : MonoBehaviour {

	public Queue<GameObject> foodQ = new Queue<GameObject>(); //holds food that cant fit on bar
	public List<GameObject> foodSpawn;
	public List<GameObject> barfood = new List<GameObject>();
	public List<Collider> triggers;
	GameObject tmp;

	void Start(){

	}

	//add to queue
	public void order(GameObject foodOrdered){
		foodQ.Enqueue (foodOrdered);
		checkBar ();
	}

	//check if there is an empty spot on the bar
	public void checkBar(){
		if (foodQ.Count > 0) {
			for (int i=0; i<barfood.Count; i++) {
				if (barfood [i] == null) {
					tmp = foodQ.Dequeue ();
                    barfood[i] = (GameObject)Instantiate(tmp, foodSpawn[i].transform.position, Quaternion.identity);
					//Instantiate (tmp, foodSpawn [i].transform.position, Quaternion.identity);
					break;
				}
			}
		}
	}

	//for when food is picked up by the waitress
	public GameObject pickup(Collider other){
		for (int i=0; i<triggers.Count; i++) {
			if (other == triggers[i]) { //if triggers are equal
				tmp = barfood [i]; //tmp var gets reference before food is set to null
				barfood [i] = null;
				checkBar (); //check bar queue

                Debug.Log(tmp == null);
				return tmp;
			}
		}
		return null;
	}

	//for when food is picked up by the waitress
	public GameObject pickup(Collider other, GameObject inHand){
		for (int i=0; i<triggers.Count; i++) {
			if (other == triggers[i]) { //if triggers are equal
				tmp = barfood [i]; //tmp var gets reference before food is set to whats in the hand
				barfood [i] = inHand;
				return tmp;
			}
		}
		return null;
	}

}
