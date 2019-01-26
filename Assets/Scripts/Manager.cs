using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public QuestSO q;
    public Text onScreenQuestText;
    public GameObject arrow;

    private void Start ()
    {
        onScreenQuestText.text = "";
    }

    public void StartQuest ()
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

        QuestItem qItem = obj.AddComponent<QuestItem> ();
        qItem.Arrow (arrow);

        //Debug.Log (string.Format (questText, obj.name, targetRoom, endRoom));
        onScreenQuestText.text = string.Format (questText, obj.name, targetRoom, endRoom);
        StartCoroutine (TextFade ());
    }

    IEnumerator TextFade ()
    {
        bool fading = true;
        while (fading)
        {
            onScreenQuestText.color = new Color (onScreenQuestText.color.r, onScreenQuestText.color.g, onScreenQuestText.color.b, onScreenQuestText.color.a - (0.3f * Time.deltaTime));
            if (onScreenQuestText.color.a <= 0.1f)
                break;
            yield return new WaitForSeconds (1 * Time.fixedDeltaTime);
        }
        fading = false;
        onScreenQuestText.text = "";
        onScreenQuestText.color = Color.black;
    }

    public void FinishQuest ()
    {

        //Debug.Log (q.completedText);
        onScreenQuestText.text = q.completedText;
        StartCoroutine (TextFade ());
        q.target.GetComponent<QuestItem> ().ByeArrow ();

    }

}
