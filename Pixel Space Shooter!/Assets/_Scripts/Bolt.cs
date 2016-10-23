using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody), typeof (Collider))]
public class Bolt : MonoBehaviour {

	public float speed;
	public float damage;

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.velocity = transform.parent.forward * speed;
	}


}
