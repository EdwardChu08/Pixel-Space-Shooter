using UnityEngine;
using System.Collections;

public class OnContactDestroy : MonoBehaviour {


	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
