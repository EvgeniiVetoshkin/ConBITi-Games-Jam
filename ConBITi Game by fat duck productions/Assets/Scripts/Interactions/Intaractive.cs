using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intaractive : MonoBehaviour
{
    [SerializeField]
    [Range (0f, 20f)]
    private float radius = 1;
    private Transform playerPos;
    private Canvas cutTreeCanvas;


    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Debug.Log("Press Space");

    }
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cutTreeCanvas = GameObject.FindGameObjectWithTag("TreeCanvas").GetComponent<Canvas>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPos.position) <= radius)
        {
            cutTreeCanvas.enabled = true;
  
        }

        if (Vector3.Distance(transform.position, playerPos.position) > radius)
        {
            cutTreeCanvas.enabled = false;

        }

        //if (Vector3.Distance(transform.position, playerPos.position) > radius)
        //{
        //    cutTreeCanvas.SetActive(false);

        //}


        if (Vector3.Distance(transform.position, playerPos.position) <= radius && Input.GetKeyDown(KeyCode.Space))
        {
            

            Interacte();
        }
    }


    public virtual void Interacte()
    {
        Debug.Log(transform.name + "does not have it`s own interaction model");
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    
}
