using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    private float interval = 0;
    public Transform target;

    private void Start()
    {
        transform.position = target.position + new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(Mathf.Sin(interval));
        transform.position = new Vector3 (transform.position.x, transform.position.y + (Mathf.Sin(interval) / 100), transform.position.z);
        transform.Rotate (0, 90 * Time.deltaTime, 0);
        interval += 2 * Time.deltaTime;
    }
}
