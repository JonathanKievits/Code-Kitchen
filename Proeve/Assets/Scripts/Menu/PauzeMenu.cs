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

    /*
        In pausegame the timescale is set to none, afterwards the pauzemenu is set to active .
        This is so you can go back to the main menu and go back into the game.
        Inputfieldholder is set to non interactible cause otherwise you can still spawn orders.
    */
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauzeMenuHolder.SetActive(true);
        InputFieldHolder.interactable = false;
    }

    //All effects explained above pausegame are undone here.
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

}
