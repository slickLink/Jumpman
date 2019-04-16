using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public bool inMain = true;
    public bool inScores = false;
    public bool inLevels = false;

    public GameObject main;
    public GameObject scores;
    public GameObject levels;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inMain)
        {
            if(inScores)
            {
                scores.SetActive(false);
                main.SetActive(true);
                inMain = true;
                inScores = false;
            }
            if(inLevels)
            {
                levels.SetActive(false);
                main.SetActive(true);
                inMain = true;
                inLevels = false;
            }
        }
    }

    public void playGame()
    {
        Debug.Log("Playing level 1");
       SceneChanger.SC.changeScene("level1");
    }
    public void selectScores()
    {
        main.SetActive(false);
        scores.SetActive(true);
        inMain = false;
        inScores = true;
        
    }
    public void selectLevels()
    {
        main.SetActive(false);
        levels.SetActive(true);
        inMain = false;
        inLevels = true;
    }
    public void ExitGame()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
    public void level1()
    {
        Debug.Log("Entering level 1");
        
        SceneChanger.SC.changeScene("level1");
    }
    public void level2()
    {
        Debug.Log("Entering level 2");
       
        SceneChanger.SC.changeScene("level2");
    }
    public void level3()
    {
        Debug.Log("Entering level 3");
       
        SceneChanger.SC.changeScene("level3");
    }

}
