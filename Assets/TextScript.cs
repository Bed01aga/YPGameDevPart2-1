using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public GameObject TextCanvas;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TextCanvas.SetActive(true);
        Destroy(TextCanvas, 10f);
    }
}
