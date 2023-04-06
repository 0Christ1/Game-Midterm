using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string currLevel;

    public void ContinueGame()
    {
        SceneManager.LoadScene(currLevel);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("level2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
