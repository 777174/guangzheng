using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [HideInInspector]
    public bool istaken;

    public bool LockUp;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            istaken = true;
            gameObject.SetActive(false);
        }       
    }
}
