using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerLevelSelect : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnLevelSelected1()
    {
        SceneManager.LoadScene(3);
    }
    public void OnLevelSelected2()
    {
        SceneManager.LoadScene(4);
    }
    public void OnLevelSelected3()
    {
        SceneManager.LoadScene(5);
    }
    public void OnLevelSelected4()
    {
        SceneManager.LoadScene(6);
    }
    public void OnLevelSelected5()
    {
        SceneManager.LoadScene(7);
    }
}
