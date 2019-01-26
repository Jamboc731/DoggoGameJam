using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : Furniture
{
    public Material brokenTV;
    public MeshRenderer tvScreen;

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.gameObject.CompareTag("Floor"))
        {

            tvScreen.material = brokenTV;
        }
    }
}
