using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<playerScript>().death();
            }
        }
    }
}
