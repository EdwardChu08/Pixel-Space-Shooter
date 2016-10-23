using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class playerHealthBar : MonoBehaviour {

	public GameObject target;
	public GameObject HealthFill;

	private Slider health;
	private Image healthFill;
	private float temp = 10.0f;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = target.GetComponent<PlayerController>();
		health = GetComponent<Slider> ();
		healthFill = HealthFill.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		temp = player.health;
		if (health.value > player.health) {
			health.value -= 1.0f;
			healthFill.color = Color.red;
		} else if (health.value < player.health) {
			health.value += 1.0f;
		} 
		if(health.value == player.health) {
			//Debug.Log ("Color reset" + health.value);
			//healthFill.color = new Color (84.0f, 255.0f, 30.0f, 255f);
			healthFill.color = Color.green;
		}

		//StartCoroutine (UpdateHealth ());
	}

	/*
	IEnumerator UpdateHealth(){
		while (health.value > player.health) {
			health.value -= 0.02f;
			healthFill.color = Color.red;
			yield return new WaitForSeconds (0.2f);
		}

		while (health.value < player.health) {
			health.value += 0.02f;
			yield return new WaitForSeconds (0.2f);
		}

		if (health.value - player.health < 0.3f) {
			//Debug.Log ("Color reset" + health.value);
			//healthFill.color = new Color (88.0f, 255.0f, 30.0f, 255f);
			healthFill.color = Color.green;
		}
	}
	*/
}
