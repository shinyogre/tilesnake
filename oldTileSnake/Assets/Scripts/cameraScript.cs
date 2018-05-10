using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class cameraScript : MonoBehaviour {
 
 
private Camera cam;
 
public List<GameObject> objects = new List<GameObject>();
 
public Vector3 position;
 
public float moveSpeed = 5.0f;
public float zoomSpeed = 2.0f;
 
public Vector3 targetPos;
 
public float distanceUpperBound = 13.30f;
public float distanceLowerBound = 0.0f;
 
public float maxOrth;
public float minOrth;
 
public float orthBuffer = 0.5f;
 
public float largetDistance;
 
public float orthRatio;
public float distRatio;
 
public float orthSize;
public float difference;
public float orthDiff;
 
 
void Start (){
 
    cam = GetComponent<Camera> ();
 
    position = transform.position;
 
    maxOrth = cam.orthographicSize;
    minOrth = maxOrth / 1.7f;
 
    //largetDistance = distanceUpperBound;
        getMaxDistance ();
    distanceLowerBound = 2.5f;
 
    orthRatio = (maxOrth - minOrth) / 100;
    distRatio = (largetDistance - distanceLowerBound) / 100;
 
}
 
private void calcPos(){
 
    Vector3 center = new Vector3 (0,0,0);
    float count = 0.0f;
 
    for (int i = 0; i < objects.Count; ++i){
        center += objects[i].transform.position;
        count ++;
    }
 
    position = center / count;
 
    targetPos = Vector3.Lerp (transform.position, (position / count), moveSpeed * Time.deltaTime);
    targetPos.z = -10.0f;
 
    gameObject.transform.position = targetPos;
}
 
private void calcZoom(){
 
    orthSize = maxOrth;
 
    getMaxDistance ();
 
    if (largetDistance > distanceUpperBound){
            orthSize = maxOrth + orthBuffer;
     
    } else if (largetDistance < distanceLowerBound){
            orthSize = minOrth + orthBuffer;
 
    } else{
        difference = (largetDistance - distanceLowerBound) / (distRatio);
        orthDiff = difference * orthRatio;
        orthSize = minOrth + orthDiff + orthBuffer;
    }
 
    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthSize, zoomSpeed * Time.deltaTime);
 
}
 
private void getMaxDistance(){
    largetDistance = 0.0f;
 
    for(int i = 0; i < objects.Count; ++i){
        for(int b = 0; b < objects.Count; ++b){
            float dist = Vector3.Distance (objects [b].transform.position, objects [i].transform.position);
 
            if(dist > largetDistance){
                largetDistance = dist;
            }
        }
    }
}
 
void Update(){
    calcPos();
    calcZoom();
}
 
public void addObjectToCamList(GameObject obj){
    this.objects.Add(obj);
}
public void removeObjectFromCamList(GameObject obj){
    if(this.objects.Contains (obj)){
        this.objects.Remove (obj);
    }
}
 
 
}