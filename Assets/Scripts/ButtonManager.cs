using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public static Action GameLaunched;
    public GameObject infoInGame;
    public GameObject menuStart;
    public GameObject pauseMenu;
    public GameObject player;


    public void LaunchGame()
    {
        Debug.Log("GAME IS LAUNCHED");
        FindObjectOfType<AudioManager>().Play("ButtonSnd");
        menuStart.SetActive(false);
        infoInGame.SetActive(true);

        if(GameLaunched != null)
        {
            GameLaunched();
        }
    }

    public void PauseButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonSnd");
        player.GetComponent<PlayerController>().starting = false;
        infoInGame.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ReplayButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonSnd");
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void CloseMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonSnd");
        infoInGame.SetActive(true);
        pauseMenu.SetActive(false);
        player.GetComponent<PlayerController>().StartDelay();
    }

}
