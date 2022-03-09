using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intaractive : MonoBehaviour
{
    public float radius = 1f;


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
