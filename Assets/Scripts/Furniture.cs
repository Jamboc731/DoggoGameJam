using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Furniture : MonoBehaviour
{
    public int value;

    Rigidbody rbody;

    bool hasUpdatedScore = false;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();

        rbody.isKinematic = true;

    }

    public virtual void Explode(Transform explosionOrigin, float explosionForce)
    {
        rbody.isKinematic = false;
        rbody.AddExplosionForce(explosionForce, explosionOrigin.transform.position, 1);

    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        Furniture furnitureInRange = collision.gameObject.GetComponent<Furniture>();
        if (furnitureInRange != null)
        {
            furnitureInRange.Explode(this.transform, 1);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            if (!hasUpdatedScore)
            {
                UIController.UpdateScore(value);
                hasUpdatedScore = true;

            }

        }

    }
}
