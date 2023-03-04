using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyScript : MonoBehaviour
{

    public float damageRadius = 1.5f;
    public float damageAmount = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ghost")
        {
            //Kill ghost
        }
    }
}
