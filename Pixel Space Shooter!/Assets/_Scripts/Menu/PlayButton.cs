using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	public void PlayClick(){
		SceneManager.LoadScene ("Main", LoadSceneMode.Single);
	}
}
