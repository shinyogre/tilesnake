using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	public GameObject currentItem = null;

	void FixedUpdate () {
		//if colliding with an interactable item
		//need to add condition here to limit item inventory to 1 item
		if(currentItem) {
			currentItem.SendMessage ("PickUp");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Item")){
			//Debug.Log(other.name);
			currentItem = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Item")){
			if (other.gameObject == currentItem){
				currentItem = null;
			}
		}
	}
}
