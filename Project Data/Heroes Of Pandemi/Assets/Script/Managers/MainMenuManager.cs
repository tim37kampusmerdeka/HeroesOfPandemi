using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string sceneName;
    public void Level1()
    {
        SceneManager.LoadScene("Loading");
        // SceneManager.LoadScene(sceneName);
    }
    public void ExitButton()
    {
        Debug.Log("QUIT THE GAME");
        Application.Quit();
    }

    public void OpenScene(string sceneToOpen)
    {
        SceneManager.LoadScene(sceneToOpen);
    }
}
