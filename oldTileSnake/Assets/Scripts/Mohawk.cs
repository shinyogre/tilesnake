using UnityEngine;
using System.Collections;
using Rewired;

public class Mohawk : MonoBehaviour {
public int playerId = 0;
public Player player;
public Vector3 moveVector;
public Vector2 v2;
//public Vector3 speedAdjust = new Vector3 (3f,3f,3f);
public float speedAdjust = 300.00f;
public bool isMovingLeft;
public bool isMovingRight;
public bool isMovingUp;
public bool isMovingDown;
Animator animator;
public Rigidbody2D rb;
//Rigidbody2D rb = ameObject.GetComponent<Rigidbody2D>();

	void Awake() {
		player = ReInput.players.GetPlayer(playerId);
		animator = GetComponent<Animator>();
		rb = gameObject.GetComponent<Rigidbody2D>();
		
	}



	void Start () {
		GameObject cam = GameObject.Find("Main Camera");
		cameraScript temp = cam.GetComponent<cameraScript>();
		temp.addObjectToCamList(this.gameObject);
	
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

		
		moveVector.x = player.GetAxis("Move Horiz");
		moveVector.y = player.GetAxis("Move Vert");

		
		if(moveVector.x != 0.0f || moveVector.y != 0.0f){
			//transform.position += new Vector3 (moveVector.x * speedAdjust.x, moveVector.y * speedAdjust.y, moveVector.z * speedAdjust.z) * Time.deltaTime;
		}
		

		if(moveVector.x != 0.0f || moveVector.y != 0.0f){
			/*/Debug.Log("force function");
			Debug.Log(v2);
			//v2 = moveVector.XY();
			v2 = new Vector2(moveVector.x,moveVector.y);
			v2.x = v2.x * speedAdjust;
			v2.y = v2.y * speedAdjust;
			rb.AddForce(v2);
			*/
			v2 = new Vector2(moveVector.x,moveVector.y);	
			rb.velocity = v2.up * speedAdjust;
		}
		
		Debug.Log(v2*speedAdjust);


		if(moveVector.x > 0.1f){isMovingRight = true;} else {isMovingRight = false;}
		if(moveVector.y > 0.1f){isMovingUp = true;} else {isMovingUp = false;}
		if(moveVector.x < -0.1f){isMovingLeft = true;} else {isMovingLeft = false;}
		if(moveVector.y < -0.1f){isMovingDown = true;} else {isMovingDown = false;}
		animator.SetBool("isMovingRight", isMovingRight);
		animator.SetBool("isMovingLeft", isMovingLeft);
		animator.SetBool("isMovingUp", isMovingUp);
		animator.SetBool("isMovingDown", isMovingDown);
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log ("collision!");
		//transform.position = transform.position - moveVector;
	}
	void OnCollisionStay2D(Collision2D collision){
		//rb.MovePosition(moveVector);
		//Debug.Log("stay");
	}


}
