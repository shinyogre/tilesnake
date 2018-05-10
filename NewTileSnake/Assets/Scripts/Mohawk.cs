using UnityEngine;
using System.Collections;
using Rewired;

public class Mohawk : MonoBehaviour {
public int playerId = 0;
public Sprite[] spriteList;
public Player player;
public Vector3 moveVector;
public Vector2 v2;
//public Vector3 speedAdjust = new Vector3 (3f,3f,0f);
public float speedAdjust= 3.0f;
public bool isMovingLeft;
public bool isMovingRight;
public bool isMovingUp;
public bool isMovingDown;

public Vector3 velocMaybe;
Animator animator;
public Rigidbody2D rb;

	void Awake() {
		player = ReInput.players.GetPlayer(playerId);
		animator = GetComponent<Animator>();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}



	void Start () {
		GameObject cam = GameObject.Find("Main Camera");
		cameraScript tempCam = cam.GetComponent<cameraScript>();
		tempCam.addObjectToCamList(this.gameObject);

		GameObject monster = GameObject.Find("Monster");
		MonsterScript tempMon = monster.GetComponent<MonsterScript>();
		tempMon.addObjectToMonsterList(this.gameObject);
	}

	void FixedUpdate () {
		
		if (player.GetButtonDown("Use Item")){
			Debug.Log ("Item Used!");
		}
		if (player.GetButtonDown("Drop Item")){
			Debug.Log ("Item Dropped!");
		}
		if (player.GetButtonDown("Dash")){
			Debug.Log ("Dash!");
		}


		velocMaybe = rb.velocity;

		moveVector.x = player.GetAxis("Move Horiz");
		moveVector.y = player.GetAxis("Move Vert");

		if(moveVector.x != 0.0f || moveVector.y != 0.0f){

			//transform.position += new Vector3 (moveVector.x * speedAdjust.x, moveVector.y * speedAdjust.y, moveVector.z * speedAdjust.z) * Time.deltaTime;

			v2 = new Vector2(moveVector.x,moveVector.y);

			v2.x = v2.x * speedAdjust;
			v2.y = v2.y * speedAdjust;

			if (rb.velocity.x > 3){
				rb.velocity = new Vector2(3,rb.velocity.y);
			}
			if (rb.velocity.y > 3){
				rb.velocity = new Vector2(rb.velocity.x, 3);
			}

			rb.velocity = new Vector3(v2.x,v2.y,0.0f);
			//Debug.Log(v2);
			//rb.AddForce(v2);
			animator.SetBool("isStopped", false);
			animator.enabled = true;
		
		}
		if(moveVector.x > 0.1f){isMovingRight = true;} else {isMovingRight = false;}
		if(moveVector.y > 0.1f){isMovingUp = true;} else {isMovingUp = false;}
		if(moveVector.x < -0.1f){isMovingLeft = true;} else {isMovingLeft = false;}
		if(moveVector.y < -0.1f){isMovingDown = true;} else {isMovingDown = false;}
		animator.SetBool("isMovingRight", isMovingRight);
		animator.SetBool("isMovingLeft", isMovingLeft);
		animator.SetBool("isMovingUp", isMovingUp);
		animator.SetBool("isMovingDown", isMovingDown);
		if(moveVector.x < 0.1f && moveVector.x > -0.1f && moveVector.y < 0.1f && moveVector.y > -0.1f){
			animator.SetBool("isStopped", true);
			animator.enabled = false;
			v2.x = 0.0f;
			v2.y = 0.0f;
		}

	}


	//void OnTriggerEnter2D(Collider2D collider){
	//	Debug.Log ("collision!");
//		isCollided = true;


//	}

//	void OnTriggerStay2D(Collider2D collider){

//		Debug.Log (collider.gameObject.transform.position.x );
	//	Debug.Log (this.transform.position.x);

//		if(collider.gameObject.transform.position.x > this.transform.position.x){
//			this.transform.position.x --;
//		}
//	}
	//void OnTriggerEnter2D(){
	//	Debug.Log("I collided with a trigger!");
	//}
}
