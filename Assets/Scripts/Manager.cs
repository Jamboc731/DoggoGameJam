using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public void StartQuest (QuestSO q)
    {
        
        RaycastHit hit;
        GameObject obj = q.target;
        Transform targSpawn = q.spawnPoint;
        Transform targEnd = q.targetPoint;
        string questText = q.questText;
        Physics.Raycast (targSpawn.position, -targSpawn.transform.up, out hit, 10, LayerMask.GetMask ("room"));
        string targetRoom = hit.collider.gameObject.name;
        Physics.Raycast (targEnd.position, -targEnd.transform.up, out hit, 10, LayerMask.GetMask ("room"));
        string endRoom = hit.collider.gameObject.name;

        Debug.Log (string.Format (questText, obj.name, targetRoom, endRoom));

    }

}
