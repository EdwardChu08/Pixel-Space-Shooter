using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		rb.angularVelocity = new Vector3(0.0f, Random.insideUnitSphere.y * tumble, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
