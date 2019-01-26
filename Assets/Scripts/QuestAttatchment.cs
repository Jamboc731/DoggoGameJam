using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAttatchment : MonoBehaviour {

    public Manager man;
    public QuestSO quest;

    private void Start ()
    {
        man = GameObject.Find ("Manager").GetComponent<Manager> ();
    }

    private void OnTriggerEnter (Collider other)
    {
        man.StartQuest (quest);
        Destroy (gameObject);
    }

}
