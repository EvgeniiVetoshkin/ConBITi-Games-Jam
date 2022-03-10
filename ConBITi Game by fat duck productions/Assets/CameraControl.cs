using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;
    private Vector3 diff;

    private void Start()
    {
        player = FindObjectOfType<navMovement>().transform;
        diff = player.position - transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.position - diff;
    }
}
