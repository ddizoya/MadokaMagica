using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		SceneManager.LoadScene ("GameScene");
	}


}
