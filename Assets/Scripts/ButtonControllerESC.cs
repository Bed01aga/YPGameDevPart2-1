using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class ButtonControllerESC : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject deadMenu;
    public static bool IsPaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !IsPaused && !KillPlayer.PlayerIsDead)
        {
            Pause();
        }
        else if(Input.GetButtonDown("Cancel") && IsPaused && !KillPlayer.PlayerIsDead)
        {
            Resume();
        }
            
    }

    public void Resume()
    {
        escMenu.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1.0f;
        Debug.Log("button Pushed");
    }

    public void Pause()
    {
        escMenu.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0.0f;
        Debug.Log("button Pushed1234");
    }

    public void DeadMenu()
    {
        deadMenu.SetActive(true);
        
        IsPaused = true;
        Time.timeScale = 0.0f;
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
        Debug.Log("button Pushed");
    }

    public void OnRestartButtonClicked()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("button Pushed");
    }
}
