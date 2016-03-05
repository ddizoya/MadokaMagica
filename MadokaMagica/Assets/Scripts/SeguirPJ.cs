using UnityEngine;
using System.Collections;

public class SeguirPJ : MonoBehaviour {
    public Transform madoka;
    public float separacion = 3f;
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(madoka.position.x + this.separacion, transform.position.y, transform.position.z);
	}
}
