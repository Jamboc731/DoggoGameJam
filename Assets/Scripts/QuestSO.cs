using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest")]
public class QuestSO : ScriptableObject
{
    public string roomName;
    public string itemName;
    public string endRoomName;
    public string questText;
    public string completedText;
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public Transform spawnPoint;
    [HideInInspector]
    public Transform targetPoint;

    private void OnEnable ()
    {
        target = GameObject.Find (itemName);
        spawnPoint = GameObject.Find (roomName).transform;
        targetPoint = GameObject.Find (endRoomName).transform;
    }

}
