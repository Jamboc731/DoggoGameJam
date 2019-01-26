using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour {

    private Transform doggo;
    private Transform smok;
    public float moveSpeed = 1;

    private void Start ()
    {
        smok = transform.GetChild (0);
        doggo = GameObject.Find ("Doggo").transform;
    }

    private void Update ()
    {
        transform.LookAt (doggo);
        transform.Translate (0, 0, -1 * moveSpeed * Time.deltaTime);
        smok.Rotate (new Vector3(90, 90, 90) * Time.deltaTime);
    }

}
