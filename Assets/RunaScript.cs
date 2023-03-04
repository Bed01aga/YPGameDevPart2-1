using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaScript : MonoBehaviour
{
    public GameObject[] needToCreate;
    // Start is called before the first frame update
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost" && Input.GetKeyDown(KeyCode.E))
        {
            foreach (var item in needToCreate)
            {
                item.gameObject.SetActive(true);
            }

        }
    }
}
