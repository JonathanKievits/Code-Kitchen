using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Loads the scene by index number
    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    // Loads the next scene in the index
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }

    // Loads the previous scene in index
    public void LoadPreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene > 0)
        {
            SceneManager.LoadScene(currentScene - 1);
        }
    }

    // Loads the scene by the given name
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    // Closes the game
    public void ExitGame()
    {
        Application.Quit();
    }
}