using UnityEngine;
using System.Collections;



public class RedPlague : MonoBehaviour {
	
	public float speed;
	public float fireRate;

	public GameObject shot;
	public Transform shotSpawnL;
	public Transform shotSpawnR;

	private float timeSinceLastShot = 0.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * -speed;
	}
	
	// Update is called once per frame
	void Update () {
		//Shooting
		timeSinceLastShot += Time.deltaTime;

		if (timeSinceLastShot > fireRate) {
			Instantiate (shot, shotSpawnL.position, shotSpawnL.rotation);
			Instantiate (shot, shotSpawnR.position, shotSpawnR.rotation);
			timeSinceLastShot = 0.0f;
		}
	}
}
