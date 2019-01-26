using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamieSecretScript : MonoBehaviour {

    public GameObject FRW;
    public float radius;
    public float offset;
    private float charge = 0;
    [SerializeField]
    private bool canFire = true;
    [HideInInspector]
    public List<GameObject> smokes = new List<GameObject>();
    //private float [] xPointsOnCircle = new float [] {};

    private void Update ()
    {
        if (Input.GetButtonDown ("Secret"))
        {
            charge = 0;
            canFire = true;
        } 
        if (Input.GetButton ("Secret"))
            charge += 6f * Time.deltaTime;
        if (charge >= 3)
        {
            if (canFire)
            {
                canFire = false;
                Secret (5);
                charge = 0;
                return;
            }
        }
        if (Input.GetButtonUp ("Secret"))
        {
            if (canFire)
            {
                canFire = false;
                if (charge < 1)
                {
                    Secret (1); charge = 0;
                }
                else
                {
                    Secret ((int) Mathf.Floor (charge));
                    charge = 0;
                }

            }
        }
            
    }

    private void Secret (int stage)
    {
        float xPos = radius;
        while (xPos > -radius)
        {
            float yPos = Mathf.Sqrt (Mathf.Pow (radius, 2) - Mathf.Pow (xPos, 2));
            smokes.Add (Instantiate (FRW, transform.position + transform.TransformDirection(new Vector3 (xPos, yPos, offset)), new Quaternion()));
            smokes.Add (Instantiate (FRW, transform.position + transform.TransformDirection(new Vector3 (xPos, -yPos, offset)), new Quaternion ()));
            xPos -= radius / 10;
        }

        foreach(GameObject smok in smokes)
        {

            smok.GetComponent<SmokeScript> ().moveSpeed *= stage;
            Destroy (smok, 1);

        }

    }

}
