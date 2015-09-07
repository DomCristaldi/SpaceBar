using UnityEngine;
using System.Collections;

public class BarSection : MonoBehaviour {

	public GameObject food;
	public bool available;

	// Use this for initialization
	void Start () {
		available = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void serve(GameObject foodOrdered, Vector3 pos){
		Instantiate(foodOrdered,pos, Quaternion.identity);
		available = false;
	}

	public void pickup(){
		Destroy (food);
		food = null;
		available = true;
	}
}
