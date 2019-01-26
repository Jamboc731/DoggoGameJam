using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingDoggoradius : MonoBehaviour {

    float AITimer = 0.1f;
    float timer;

    public float explosionRadius;
    public float explosionForce;
    public Transform explosionOrigin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < AITimer)
            return;

        Collider[] colliders = Physics.OverlapSphere(explosionOrigin.position, explosionRadius);

        foreach (Collider nearbyItem in colliders)
        {
            Furniture furnitureInRange = nearbyItem.GetComponent<Furniture>();
            if (furnitureInRange != null)
            {
                furnitureInRange.Explode(this.transform, explosionForce);
            }
        }
	}
}
