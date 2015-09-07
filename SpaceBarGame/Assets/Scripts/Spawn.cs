using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	public List<GameObject> spawnPoints;
	public List<GameObject> customers;
	public List<GameObject> food;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			int c = Random.Range (0,customers.Count);
			int s = Random.Range(0,spawnPoints.Count);
			int f = Random.Range (0,food.Count);
			GameObject tmp = customers[c];
			tmp.GetComponent<Customer>().food = food[f];
			Instantiate(tmp,spawnPoints[s].transform.position,Quaternion.identity);
		}
	}
}
