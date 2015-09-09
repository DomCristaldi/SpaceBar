using UnityEngine;
using System.Collections;

[System.Serializable]
public class Food : MonoBehaviour {

	public GameObject spawnPoint;
	public Collider trigger;
	public GameObject food;

	public GameObject pickup(){
		if (food != null) {
			GameObject tmp = food;
			food = null;
			return tmp;
		}
		return food;
	}
}
