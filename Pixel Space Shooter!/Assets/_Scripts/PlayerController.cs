using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary2 {
	public float xMin, xMax, zMin, zMax, rotMin, rotMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary2 boundary;
	public float tilt;
	public float fireRate;
	public float health;

	public GameObject shot;
	public GameObject playerExplosion;
	public Transform shotSpawn;
	public GameController gameController;

	//public Text healthText;
	//public Slider healthBar;

	private Rigidbody rb;
	private AudioSource aud;


	private float timeSinceLastShot = 0.0f;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		aud = GetComponent<AudioSource> ();

	}

	void Update(){

	
		//Shooting
		timeSinceLastShot += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timeSinceLastShot > fireRate) {
			aud.Play ();
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			timeSinceLastShot = 0.0f;
		}

		//Check Health
		//healthText.text = "Health: " + health;
		//StartCoroutine (HealthBarUpdate ());


		if (health <= 0) {
			Destroy (gameObject);
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();
		}
	}

	/*
	IEnumerator HealthBarUpdate(){
		
			while (healthBar.value > health) {
				healthBar.value -= Time.deltaTime;
				yield return new WaitForSeconds (0.1f);
			}

	}
	*/

	void FixedUpdate () {

		//Basic Movement, sets velocity directly instead of adding force
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 playerMove = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = playerMove * speed;

		//Clamp position
		Vector3 tmpPos = rb.position;
		tmpPos.x = Mathf.Clamp(tmpPos.x, boundary.xMin, boundary.xMax);
		tmpPos.z = Mathf.Clamp (tmpPos.z, boundary.zMin, boundary.zMax);
		rb.position = tmpPos;



		//Rotation effect as a function of the velocity in the x-axis
		//rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);


	}


}
