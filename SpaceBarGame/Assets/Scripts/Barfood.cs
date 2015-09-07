using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barfood : MonoBehaviour {

	public Queue<GameObject> food = new Queue<GameObject>(); //holds food that cant fit on bar
	public List<GameObject> bar; //bar sections
	public List<GameObject> foodSpawn;


	//add to queue
	public void order(GameObject foodOrdered){
		food.Enqueue (foodOrdered);
		checkBar ();
	}

	//check if there is an empty spot on the bar
	public void checkBar(){
		if (food.Count > 0) {
			for (int i=0; i<bar.Count; i++) {
				Debug.Log(bar[i]);
				if(bar[i].GetComponent<BarSection>().available == true){ //if spot is free, spawn food
                    Debug.Log("boom");
					bar[i].GetComponent<BarSection>().serve (food.Dequeue(), foodSpawn[i].transform.position);
					break;
				}
			}
		}
	}

}
