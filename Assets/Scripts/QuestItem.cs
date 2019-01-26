using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class QuestItem : MonoBehaviour
{
    private FixedJoint fj = null;
    private bool collected = false;
    private Manager man;

    private void Start ()
    {
        man = GameObject.Find ("Manager").GetComponent<Manager> ();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            fj = other.gameObject.transform.GetChild (2).GetComponent<FixedJoint> ();
        }
        if (!collected)
        {
            if (other.CompareTag ("Player"))
            {
                fj.breakForce = Mathf.Infinity;
                fj.connectedBody = gameObject.GetComponent<Rigidbody> ();
                collected = true;
            }
        }
        else
        {
            if (other.CompareTag ("DeliverPoint"))
            {
                fj.breakForce = 0;
                gameObject.GetComponent<Collider> ().isTrigger = false; gameObject.GetComponent<Rigidbody> ().useGravity = true;
                man.FinishQuest ();
            }
        }
    }

}
