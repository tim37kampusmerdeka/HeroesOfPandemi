using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string sceneName;
    public void Level1()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitButton()
    {
        Debug.Log("QUIT THE GAME");
        Application.Quit();
    }
}
