using UnityEngine;
using System.Collections;

public class enemyBolt : MonoBehaviour {
	
	public float enemyBoltDamage;
	public float speed;

	private Rigidbody rb;

	void Start(){
		//Move forward
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other){
		//Damage player
		if (other.tag == "Player") {
			PlayerController player = other.GetComponent<PlayerController> ();
			Destroy (gameObject);

			player.health = player.health - enemyBoltDamage;

			//Debug.Log ("Player damaged by bolt, player health: " + player.health);
		}
	}

}
