using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CatsLife : MonoBehaviour
{
    public static int totalbeans = 0;
    private Rigidbody rb;
    public GameObject allbeans;

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
        Debug.Log("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        allbeans.BroadcastMessage("Zero");
    }
}
