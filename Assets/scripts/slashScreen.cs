using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashScreen : MonoBehaviour
{

	public void enterGame()
    {
        Debug.Log("main menu...");
        SceneChanger.SC.changeScene("main menu");
    }
}
