using UnityEngine;
using System.Collections;

public class ScrollingBg : MonoBehaviour {

	public float speed;

	private MeshRenderer mr;
	private Material mat;

	void Start (){
		
		mr = GetComponent<MeshRenderer> ();
		mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x = Random.value;

		mat.mainTextureOffset = offset;


	}
	
	// Update is called once per frame
	void Update () { 

		Vector2 offset = mat.mainTextureOffset;

		offset.y += Time.deltaTime * speed;

		mat.mainTextureOffset = offset;
	}
}
