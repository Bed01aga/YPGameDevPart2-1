using System;
using UnityEngine;
using UnityEngine.UI;

public class CheckMessageButtonF : MonoBehaviour
{
    public Image imgButtonF;

    private bool _playerOnArea;

    private void Start()
    {
        _playerOnArea = false;
        imgButtonF = GameObject.Find("ImgButtonF").GetComponent<Image>();
        imgButtonF.enabled = false;
    }
    
private void Update()
    {
        if (_playerOnArea)
        {
            imgButtonF.enabled = true;
            
        }
        else
        {
            imgButtonF.enabled = false;
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _playerOnArea = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            _playerOnArea = false;
        }
    }
    
    
}
