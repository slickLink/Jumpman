
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger SC;

    private void Awake()
    {
        if(SC == null)
        {
            SC = this;
        }
        DontDestroyOnLoad(this);
    }

    public void changeScene( string name)
    {
        SceneManager.LoadScene(name);
    }

}
