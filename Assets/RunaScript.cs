using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaScript : MonoBehaviour
{
    public GameObject[] needToCreate;
    private bool ghostState = false;

    // Start is called before the first frame update

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ghostState = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ghostState = false;
    }
    private void Update()
    {
        if (ghostState && Input.GetKeyDown(KeyCode.E))
        {
            if (needToCreate != null)
            {
                foreach (var item in needToCreate)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
    }
    
}
