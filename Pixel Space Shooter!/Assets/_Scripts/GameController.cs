using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard, redPlague, purpleInterceptor;
	public Vector3 spawnValue;

	public float spawnWait, startWait, waveWait;

	public Text scoreText, loseText, restartText;


	private int score;
	private float leftGameEdge = -3.0f;
	private float rightGameEdge = 3.0f;
	private bool gameOver, restart;

	// Use this for initialization
	void Start(){
		UpdateScore ();
		StartCoroutine (SpawnWaves());
		gameOver = restart = false;
		loseText.text = restartText.text = "";
		score = 0;

	}


	
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			//Spawn 8-14 asteroids
			int asteroidCount = Mathf.RoundToInt(Random.Range (8.0f, 14.0f));
			StartCoroutine (SpawnAsteroidWave (asteroidCount));

			yield return new WaitForSeconds (Random.Range(0.0f,2.0f)+2.0f);

			//Spawn Red Plague Wave or Purple Interceptor
			if (Random.Range (0.0f, 3.0f) > 1.0f) {
				int redPlagueCount = Mathf.RoundToInt (Random.Range (2.0f, 5.0f));
				StartCoroutine (SpawnRedPlagueWave (redPlagueCount));
			} else {
				StartCoroutine (SpawnPurpleInterceptor ());
			}
			//Break loop
			if (gameOver) {
				break;
			}

			yield return new WaitForSeconds (waveWait);
		}
	}


	//Spawn num of asteroids
	IEnumerator SpawnAsteroidWave(int num){
		
		//Debug.Log ("Asteroid Spawned: " + num);

		for (int i = 0; i < num; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (leftGameEdge, rightGameEdge), 0, spawnValue.z);
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
			Vector3 spawnRedPlague = new Vector3 (0, 0, spawnValue.z);
			Quaternion spawnRot = Quaternion.identity;
			Instantiate (redPlague, spawnRedPlague, spawnRot);
			yield return new WaitForSeconds (spawnWait);
			num--;


			for (int i = 0; i < num/2; i++) {
				Vector3 spawnRedPlague2 = new Vector3 (rightGameEdge * (i+1)/(num/2+1), 0, spawnValue.z);
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
				Vector3 spawnRedPlague = new Vector3 (rightGameEdge / (num + 1) + width, 0, spawnValue.z);
				Quaternion spawnRot = Quaternion.identity;
				Instantiate (redPlague, spawnRedPlague, spawnRot);

				//Debug.Log (spawnRedPlague.x + " " + -spawnRedPlague.x);

				spawnRedPlague.x = -spawnRedPlague.x;
				Instantiate (redPlague, spawnRedPlague, spawnRot);
				yield return new WaitForSeconds (spawnWait);
			}
		}
			
	}

	IEnumerator SpawnPurpleInterceptor(){
		Vector3 spawnPos = new Vector3 (0, 0, spawnValue.z);
		Quaternion spawnRot = Quaternion.identity;
		Instantiate (purpleInterceptor, spawnPos, spawnRot);
		yield return new WaitForSeconds (spawnWait);
	}

	void Update(){
		if(restart && Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene("Main");
		}
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score; 
	}

	public void AddScore(int addScore){
		score += addScore;
		UpdateScore ();
	}

	public void GameOver(){
		gameOver = true;
		loseText.text = "You Lose!";
		restart = true;
		restartText.text = "Press 'R' to restart";
	}
}
