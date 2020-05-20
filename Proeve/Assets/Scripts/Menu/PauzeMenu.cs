using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauzeMenuHolder;
    [SerializeField] private InputField InputFieldHolder;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauzeMenuHolder.SetActive(true);
        InputFieldHolder.interactable = false;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        PauzeMenuHolder.SetActive(false);
        InputFieldHolder.interactable = true;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OptionsMenu()
    {

    }
}
