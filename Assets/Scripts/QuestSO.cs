using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest")]
public class QuestSO : ScriptableObject
{

    public GameObject target;
    public string questText;
    public Transform spawnPoint;
    public Transform targetPoint;
	
}
