using UnityEngine;
using System.Collections;

public class PurpleInterceptor : MonoBehaviour {

	public float speed;
	public float fireRate;
	public float movementWaitTime;


	public GameObject shot;
	public Transform shotSpawn;


	private float timeSinceLastShot;


	private float randx, randz;
	private Vector3 randPos;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		timeSinceLastShot = fireRate / 2;
		StartCoroutine (GetMovementPos ());
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastShot += Time.deltaTime;

		if (timeSinceLastShot > fireRate) {
			
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			timeSinceLastShot = 0.0f;
		}

		if (transform.position - randPos != Vector3.zero) {
			float step = speed * Time.deltaTime;
			transform.parent.position = Vector3.MoveTowards (transform.parent.position, randPos, step);
			//Debug.Log(randPos);
			//rb.AddForce((randPos-transform.parent.position).normalized * speed);
		}
	}

	IEnumerator GetMovementPos(){
		while (true) {
			randx = Random.Range (-2.5f, 2.5f);
			randz = Random.Range (6.0f, 8.0f);
			randPos = new Vector3(randx, 0, randz);


			yield return new WaitForSeconds (movementWaitTime);
		}
	}
}
