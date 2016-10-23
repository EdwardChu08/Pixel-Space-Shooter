using UnityEngine;
using System.Collections;

public class BoundaryDestroyPlayerBolts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "playerBolt") {
			Destroy (other.gameObject);
			Destroy (other.transform.parent.gameObject);
		}
	}
}
