using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreenConditions : MonoBehaviour {

    public OwnerScript owner;
    public UIController score;

    public Scene lazyDoggoScene;
    public Scene bestDoggoScene;
    public Scene badDoggoScene;
    public Scene worstDoggoScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(owner.ownerProgress.value >= .99f)
        {
            EndingScreen();
        }
	}

    public void EndingScreen()
    {
        int _score;
        UIController.GetScore(out _score);

        if(_score < 200)
        {
            //LAZY DOGGO
            SceneManager.LoadScene("lazyDoggoScene");
        }

        if (_score < 5000)
        {
            //BEST DOGGO
            SceneManager.LoadScene("bestDoggoScene");
        }

        if (_score > 5000)
        {
            //MODERATE DOGGO
            SceneManager.LoadScene("badDoggoScene");
        }

        if (_score > 10000)
        {
            //WORSTEST DOGGO
            SceneManager.LoadScene("worstDoggoScene");
        }
    }
}
