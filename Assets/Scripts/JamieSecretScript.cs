using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamieSecretScript : MonoBehaviour {

    public GameObject FRW;
    public float radius;
    public float offset;

    private List<GameObject> smokes = new List<GameObject>();
    //private float [] xPointsOnCircle = new float [] {};

    private void Update ()
    {
        if (Input.GetButtonDown ("Secret"))
            Secret ();
    }

    private void Secret ()
    {
        float xPos = radius;
        while (xPos > -radius)
        {
            float yPos = Mathf.Sqrt (Mathf.Pow (radius, 2) - Mathf.Pow (xPos, 2));
            smokes.Add (Instantiate (FRW, transform.position + new Vector3 (xPos, yPos, offset), new Quaternion()));
            smokes.Add (Instantiate (FRW, transform.position + new Vector3 (xPos, -yPos, offset), new Quaternion ()));
            xPos -= radius / 10;
        }



    }

}
