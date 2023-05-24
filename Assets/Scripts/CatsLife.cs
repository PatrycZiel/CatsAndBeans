using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CatsLife : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        //rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
