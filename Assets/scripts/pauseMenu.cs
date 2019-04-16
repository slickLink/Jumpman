using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject menuUI;
    public GameObject winUI;
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    public void ResumeGame()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    private void PauseGame()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void loadMenu()
    {
        SceneChanger.SC.changeScene("main menu");
    }

    public void QuitGame()
    {
        SceneChanger.SC.changeScene("splash screen");
    }

    public void WinGame()
    {
        menuUI.SetActive(false);
        winUI.SetActive(true);
    }
}
