using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-transform.right * 10);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right * 10);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * 10);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * 10);
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(transform.up, ForceMode.Impulse);
    }
}
