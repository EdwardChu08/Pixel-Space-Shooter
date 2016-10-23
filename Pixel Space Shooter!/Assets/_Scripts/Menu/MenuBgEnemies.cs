using UnityEngine;
using System.Collections;

public class MenuBgEnemies : MonoBehaviour {

	public GameObject hazard, redPlague;
	public Vector3 spawnValue;

	public float spawnWait, startWait, waveWait;

	private float leftGameEdge = -3.0f;
	private float rightGameEdge = 3.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves());
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			//Spawn 8-14 asteroids
			int asteroidCount = Mathf.RoundToInt(Random.Range (8.0f, 14.0f));
			StartCoroutine (SpawnAsteroidWave (asteroidCount));

			yield return new WaitForSeconds (Random.Range(0.0f,2.0f)+2.0f);

			//Spawn Red Plague Wave, to do: rand num of red plagues
			int redPlagueCount = Mathf.RoundToInt(Random.Range (2.0f, 5.0f));
			StartCoroutine (SpawnRedPlagueWave (redPlagueCount));


			yield return new WaitForSeconds (waveWait);
		}
	}


	//Spawn num of asteroids
	IEnumerator SpawnAsteroidWave(int num){

		//Debug.Log ("Asteroid Spawned: " + num);

		for (int i = 0; i < num; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (leftGameEdge, rightGameEdge), 7.0f, 0);
			Quaternion spawnRotation = Quaternion.identity;

			Instantiate (hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
	}


	//Spawn num of red plagues
	IEnumerator SpawnRedPlagueWave(int num){

		//Debug.Log ("Red Plague Spawned: " + num);

		//Odd num
		if (num % 2 == 1) {
			Vector3 spawnRedPlague = new Vector3 (0, 7.0f, 0);
			Quaternion spawnRot = Quaternion.identity;
			Instantiate (redPlague, spawnRedPlague, spawnRot);
			yield return new WaitForSeconds (spawnWait);
			num--;


			for (int i = 0; i < num/2; i++) {
				Vector3 spawnRedPlague2 = new Vector3 (rightGameEdge * (i+1)/(num/2+1), 7.0f, 0);
				Instantiate (redPlague, spawnRedPlague2, spawnRot);
				spawnRedPlague2.x = -spawnRedPlague2.x;
				Instantiate (redPlague, spawnRedPlague2, spawnRot);
				yield return new WaitForSeconds (spawnWait);
			}


		}

		//even num
		else{ 
			for (int i = 0; i < num/2; i ++) {
				float width = 6.0f * (i) / (num + 1);
				Vector3 spawnRedPlague = new Vector3 (rightGameEdge / (num + 1) + width, 7.0f, 0);
				Quaternion spawnRot = Quaternion.identity;
				Instantiate (redPlague, spawnRedPlague, spawnRot);

				//Debug.Log (spawnRedPlague.x + " " + -spawnRedPlague.x);

				spawnRedPlague.x = -spawnRedPlague.x;
				Instantiate (redPlague, spawnRedPlague, spawnRot);
				yield return new WaitForSeconds (spawnWait);
			}
		}

	}
}
