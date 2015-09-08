using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barfood : MonoBehaviour {

	public Queue<GameObject> food = new Queue<GameObject>(); //holds food that cant fit on bar
	public List<GameObject> foodSpawn;
	public List<GameObject> barfood = new List<GameObject>();
	GameObject tmp;

	void Start(){

	}

	//add to queue
	public void order(GameObject foodOrdered){
		food.Enqueue (foodOrdered);
		checkBar ();
		//Instantiate(food.Dequeue(),foodSpawn[0].transform.position,Quaternion.identity);
	}

	//check if there is an empty spot on the bar
	public void checkBar(){
		for (int i=0; i<barfood.Count; i++) {
			if(barfood[i] == null){
				tmp = food.Dequeue();
				barfood[i] = tmp;
				Instantiate(tmp,foodSpawn[i].transform.position,Quaternion.identity);
				break;
			}
		}
	}

}
