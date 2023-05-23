using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    [Range(0.1f, 5f)]
    public float WaitBetweenWobbles = 0.5f;

    [Range(1f, 50f)]
    public float Intensity = 10f;

    Quaternion _targetAngle;

    void Start()
    {
        InvokeRepeating("ChangeTarget", 0, WaitBetweenWobbles);
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetAngle, Time.deltaTime);
    }
    void ChangeTarget()
    {
        var intensity = Random.Range(0.1f, Intensity);
        var curve = Mathf.Sin(Random.Range(0, Mathf.PI * 2));
        _targetAngle = Quaternion.Euler(Vector3.forward * curve * intensity);
    }
}
