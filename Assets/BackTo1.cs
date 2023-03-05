using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTo1 : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadSceneDelayed", 10f);
    }
    void LoadSceneDelayed()
    {
        SceneManager.LoadScene("NameOfYourScene");
    }
}
