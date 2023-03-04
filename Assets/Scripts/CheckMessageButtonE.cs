using UnityEngine;
using UnityEngine.UI;

public class CheckMessageButtonE : MonoBehaviour
{
    public Image imgButtonE;

    private bool _playerOnArea;

    private void Start()
    {
        _playerOnArea = false;
        imgButtonE = GameObject.Find("ImgButtonE").GetComponent<Image>();
        imgButtonE.enabled = false;
    }
    
    private void Update()
    {
        if (_playerOnArea)
        {
            imgButtonE.enabled = true;
            
        }
        else
        {
            imgButtonE.enabled = false;
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ghost")) {
            _playerOnArea = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ghost")) {
            _playerOnArea = false;
        }
    }
}
