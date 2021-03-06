using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField]
    [Range (0f, 20f)]
    private float radius = 1;
    private Transform playerPos;
    private Transform treePos;


    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Debug.Log("Press Space");

    }
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        treePos = GameObject.FindGameObjectWithTag("TreeMid").GetComponent<Transform>();
        Init();
    }
    public virtual void Init()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(transform.position, playerPos.position) <= radius)
        {
            playerPos.LookAt(treePos);
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
