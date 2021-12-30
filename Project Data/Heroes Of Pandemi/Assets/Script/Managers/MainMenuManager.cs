using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
<<<<<<< HEAD
    public void Level1()
    {
        SceneManager.LoadScene("Gameplay-Nurul");
=======
    public string sceneName;
    public void Level1()
    {
        SceneManager.LoadScene(sceneName);
>>>>>>> 51b31aff13879f9e6f78b862d19ae0608c1af15f
    }
    public void ExitButton()
    {
        Debug.Log("QUIT THE GAME");
        Application.Quit();
    }
}
