using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static Text damageText;

    public static int scoreValue = 0;

	// Use this for initialization
	void Start () {
        damageText = GameObject.FindGameObjectWithTag("DamageText").GetComponent<Text>();
        UpdateScore(0);
	}
	
	public static void UpdateScore(int value)
    {
        scoreValue += value;
        damageText.text = "£" + scoreValue; 
    }

}
