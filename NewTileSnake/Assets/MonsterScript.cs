using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

	public int closestObj;
	public float smallestDistance = 1000.0f;
	public bool isLure = false;
	public float speed = 0.1f;
	public float maxSpeed = 1.5f;
	public float childSpeed = 10.0f;
	public float childMaxSpeed;
	public float closeness;
	public Transform child;
	public List<GameObject> objects = new List<GameObject>();
	public Vector3[] playerPosition;
	public float[] dist;




	// Use this for initialization
	void Start () {
		GameObject cam = GameObject.Find("Main Camera");
		cameraScript tempCam = cam.GetComponent<cameraScript>();
		tempCam.addObjectToCamList(this.gameObject);
		Transform child = this.gameObject.transform.GetChild(1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isLure == false){
			calcPlayerPos();
			lookAtIt();
			lookAtChild();
			if(speed < maxSpeed){
				speed ++;
			} else if(speed > maxSpeed){
				speed --;
			}

		}


	}

	void lookAtChild(){
		//Transform target = objects[closestObj].transform;

		transform.LookAt(child);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);
		transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
	}


	void lookAtIt(){
		Transform target = objects[closestObj].transform;
		child.transform.LookAt(target);
		child.transform.Rotate(new Vector3(0,-90,0),Space.Self);
		child.transform.Translate(new Vector3(childSpeed*Time.deltaTime,0,0));
		closeness = Vector3.Distance(child.transform.position, target.position) * 10;
		childMaxSpeed = closeness;

		if(childSpeed < childMaxSpeed){
				childSpeed ++;
			} else if(childSpeed > childMaxSpeed){
				childSpeed --;
			}
	}



	private void calcPlayerPos(){
		playerPosition = new Vector3[objects.Count];
		dist = new float[objects.Count];
		Vector3 center = new Vector3 (0,0,0);
		float count = 0.0f;

		for (int i = 0; i < objects.Count; ++i){
			playerPosition[i] += objects[i].transform.position;

			dist[i] = Vector3.Distance (objects [i].transform.position, this.transform.position);

			count ++;
		}

		getMinDistance();
}


	private void getMinDistance(){
	smallestDistance = 1000f;

	for(int i = 0; i < objects.Count; ++i){
		float distanceMin = Vector3.Distance (objects [i].transform.position, this.transform.position);

		if(distanceMin < smallestDistance){
			smallestDistance = distanceMin;
			closestObj = i;			
		}
	}
}




	public void addObjectToMonsterList(GameObject obj){
	this.objects.Add(obj);
}
	public void removeObjectFromMonsterList(GameObject obj){
	if(this.objects.Contains (obj)){
		this.objects.Remove (obj);
	}
}

}
