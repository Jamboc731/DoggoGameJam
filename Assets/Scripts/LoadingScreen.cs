using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    public Image[] shafts;
    private AsyncOperation loading;

    private void Start()
    {

        loading = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        foreach(var shaft in shafts)
        {
            shaft.fillAmount = loading.progress;
        }
    }

}
