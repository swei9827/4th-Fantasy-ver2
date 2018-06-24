using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int SceneIndex = 1;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneIndex); ///get the next level after pressting start
	}

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    /*public void Remapping()
    {
        Debug.Log("remapping controls");
    }*/
}
