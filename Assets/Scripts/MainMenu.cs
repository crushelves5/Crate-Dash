using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject instructionScreen;

	public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Instructions()
    {
        if (!instructionScreen.activeSelf)
        {
            instructionScreen.SetActive(true);
        }
        else
        {
            instructionScreen.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
