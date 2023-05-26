using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanCollecter : MonoBehaviour
{
    public static int  totalbeans = 0;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D c2D)
    {
        if (c2D.CompareTag("Player"))
        {
            totalbeans++;
            Destroy(gameObject);
        }
    }
}
