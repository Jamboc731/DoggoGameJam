using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public QuestSO activeQuest;

    public void StartQuest (QuestSO q)
    {

        GameObject obj = q.target;
        Transform targSpawn = q.spawnPoint;
        Transform targEnd = q.targetPoint;
        string questText = q.questText;

        Debug.Log (string.Format (questText, obj.name));

    }

}
