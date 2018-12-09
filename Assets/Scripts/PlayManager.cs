using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayManager : MonoBehaviour {

    public GameObject pauseScreen;
    bool paused;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
        paused = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
		
	}

    public void Pause()
    {
        if (paused) { Resume(); }
        else
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            paused = true;
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void Reload()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
