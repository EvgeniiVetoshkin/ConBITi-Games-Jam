using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField]
    [Range (0f, 4f)]
    private float radius = 1;
    private Transform playerPos;


    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Debug.Log("Press Space");

    }
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Init();
    }
    public virtual void Init()
    {
        
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, playerPos.position) <= radius && Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }


    public virtual void Interact()
    {
        Debug.Log(transform.name + "does not have it`s own interaction model");
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
