using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (transform.position.x, Mathf.Sin (Time.time), transform.position.z);
        transform.Rotate (0, 90 * Time.deltaTime, 0);
    }
}
