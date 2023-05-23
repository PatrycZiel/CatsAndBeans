using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsLife : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("death");
    }
}
