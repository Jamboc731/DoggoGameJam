using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCollisionScripts : MonoBehaviour {

    public float radius;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (Collider nearbyItem in colliders)
        {
            Furniture furniture = nearbyItem.GetComponent<Furniture>();
            if (furniture != null)
            {
                furniture.Explode(this.transform, 150);
            }
        }
	}
}
