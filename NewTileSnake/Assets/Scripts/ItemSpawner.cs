using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSpawner : MonoBehaviour {
	public GameObject OrchidBulb;
	public GameObject Invisibility;
	public GameObject Lightning;
	public GameObject Rock;
	public List<GameObject> Items = new List<GameObject>();

	public Transform[] rectangleObject;
	public Transform[] rectanglePlyKey;
	public Transform[] doorObject; 
	public Transform thisChild;
	public int spawnCounter;
	
	
	void Start () {

		ObjectStart();
		PlyKeyStart();

	}

	public void ObjectStart(){
		spawnCounter = 0;
		Items.Add(OrchidBulb);
		Items.Add(Invisibility);
		Items.Add(Lightning);
		Items.Add(Rock);
		//Doors, player spawn points, and the key are not currently being added to the Items List
		thisChild = this.gameObject.transform.GetChild(4);

		foreach( Transform child in thisChild.gameObject.transform) {
			spawnCounter ++;
		}

		rectangleObject = new Transform[spawnCounter-1];

		for (int i=0; i < spawnCounter-1; i++) {
			rectangleObject[i] = thisChild.gameObject.transform.GetChild(i);
			SpawnObjectNow(Items[Random.Range(0,Items.Count)],i);
		} 
	}

	public void PlyKeyStart(){
		spawnCounter = 0;
		thisChild = this.gameObject.transform.GetChild(2);

		foreach( Transform child in thisChild.gameObject.transform) {
			spawnCounter ++;
		}

		rectanglePlyKey = new Transform[spawnCounter-1];

		for (int i=0; i < spawnCounter-1; i++) {
			rectanglePlyKey[i] = thisChild.gameObject.transform.GetChild(i);
			//SpawnPlyKeyNow(someGameObject,somePlaceID);
		} 
	}

	public void DoorStart(){
		spawnCounter = 0;
		thisChild = this.gameObject.transform.GetChild(3);

		foreach( Transform child in thisChild.gameObject.transform) {
			spawnCounter ++;
		}

		doorObject = new Transform[spawnCounter-1];

		for (int i=0; i < spawnCounter-1; i++) {
			doorObject[i] = thisChild.gameObject.transform.GetChild(i);
			//SpawnDoorNow(someGameObject,somePlaceID);
		} 
	}
	
	public void SpawnObjectNow(GameObject Object, int place){
		Instantiate(Object,rectangleObject[place].position, Quaternion.identity);
	}

	public void SpawnPlyKeyNow(GameObject Object, int place){
		Instantiate(Object,rectanglePlyKey[place].position, Quaternion.identity);
	}

	public void SpawnDoorNow(GameObject Object, int place){
		Instantiate(Object,doorObject[place].position, Quaternion.identity);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
