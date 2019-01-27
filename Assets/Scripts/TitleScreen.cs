using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public void NextScene()
    {//will load the level 1 scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void MainMenu()
    {//loads the main menu
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {//quit game
        Application.Quit();
    }
}
