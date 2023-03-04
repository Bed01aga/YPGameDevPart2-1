using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerESC : MonoBehaviour
{
    [SerializeField] private GameObject escMenu;
    private bool isPaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            Pause();
        }
        else if(Input.GetButtonDown("Cancel") && isPaused)
        {
            Resume();
        }
            
    }

    public void Resume()
    {
        escMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
        Debug.Log("button Pushed");
    }

    public void Pause()
    {
        escMenu.SetActive(true);
        isPaused = true;
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
