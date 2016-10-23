using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	void OnTriggerExit(Collider other) {
		
			Destroy(other.gameObject);

		//Destroy asteroid parent game object
		if (other.tag != "enemyBolt") {
			Destroy (other.transform.parent.gameObject);
		}
	}

}
