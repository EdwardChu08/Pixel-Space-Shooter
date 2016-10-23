using UnityEngine;
using System.Collections;

public class EnemyBolt_PurpleInterceptor : MonoBehaviour {

	public float enemyBoltDamage;
	public float speed;
	public float chaseTime;



	private GameObject player;
	private Rigidbody rb;

	private float chaseCounter = 0;
	private Vector3 endDirection;

	//Find Player gameObject
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.Log ("Player not found!");
		}
		rb = GetComponent<Rigidbody> ();

	}
	

	void Update () {
		//Player destroyed
		if (player == null) {
			rb.velocity = -transform.parent.forward * speed;
		} else if (chaseCounter < chaseTime) {
			//Chasing Player
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, step);
			chaseCounter += Time.deltaTime;
			endDirection = player.transform.position-transform.position;
		} else {
			//Continuing in last direction
			rb.velocity = endDirection.normalized * speed;
		}
	}




	void OnTriggerEnter(Collider other){
		//Damage player
		if (other.tag == "Player") {
			PlayerController player = other.GetComponent<PlayerController> ();
			Destroy (gameObject);
			Destroy (transform.parent.gameObject);

			player.health = player.health - enemyBoltDamage;

			//Debug.Log ("Player damaged by bolt, player health: " + player.health);
		}
	}
}
