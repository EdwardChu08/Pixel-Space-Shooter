using UnityEngine;
using System.Collections;

public class Enemy: MonoBehaviour {

	public float health, bodyDamage;
	public int scoreValue;
	public GameObject explosionEnemy;

	public GameController gameController;
	private GameObject gameControllerObject;

	//Get game controller
	void Start ()
	{
		gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}


	void OnTriggerEnter(Collider other){
		//Collide with player bolts
		if (other.tag == "playerBolt") {
			//Debug.Log ("Hit!");

			Bolt incomingBolt = other.GetComponent<Bolt>();
			health = health - incomingBolt.damage;
			Destroy (other.gameObject);
			Destroy (other.transform.parent.gameObject);

		}

		//Collide with player
		if (other.tag == "Player") {
			PlayerController player = other.GetComponent<PlayerController> ();
			Destroy (gameObject);
			Destroy (transform.parent.gameObject);
			Instantiate (explosionEnemy, transform.position, transform.rotation);
			player.health = player.health - bodyDamage;

			//Debug.Log ("Body damage, player health:  " + player.health);
		}

		//Destroy when health = 0
		if (health <= 0) {
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
			Destroy (transform.parent.gameObject);
			Instantiate (explosionEnemy, transform.position, transform.rotation);
		}
			
	}


}
