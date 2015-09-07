using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barfood : MonoBehaviour {

	public Queue<GameObject> food = new Queue<GameObject>(); //holds food that cant fit on bar
	public List<GameObject> bar; //whether food is on that spot
	public List<GameObject> foodSpawn;

	void Start(){

	}

	//add to queue
	public void order(GameObject foodOrdered){
		food.Enqueue (foodOrdered);
		checkBar ();
	}

	//check if there is an empty spot on the bar
	public void checkBar(){
		if (food.Count > 0) {
			for (int i=0; i<bar.Count; i++) {
				if(bar[i].GetComponent<BarSection>().available == false){ //if spot is free, spawn food
					Instantiate(food.Dequeue(),foodSpawn[i].transform.position, Quaternion.identity);
					bar[i].GetComponent<BarSection>().available = true;
					break;
				}
			}
		}
	}

	public void pickup(){

	}

}
