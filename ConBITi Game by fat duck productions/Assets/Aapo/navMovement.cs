using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;


public class navMovement : MonoBehaviour
{
    public NavMeshAgent _Agent;
    public Camera cam;
    public NavMeshAgent agent;
    public CinemachineFollowZoom cmfz;
   public Rigidbody rb;
    


    private void Awake()
    {
        //rb.maxAngularVelocity = 0;
        _Agent = GetComponent<NavMeshAgent>();
    }


    private IEnumerator ZoomWait()
    {
        cmfz.m_MinFOV = 5f;
        yield return new WaitForSeconds(5f);
        cmfz.m_MinFOV = 60f;
    }

    //private IEnumerator jumpWait()
    //{
    //    _Agent.enabled = false;
    //    rb.AddForce(Vector3.up * 5000f);
    //    yield return new WaitForSeconds(1f);
    //    _Agent.enabled = true;
        
    //}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine("ZoomWait");
        }

        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Debug.Log("jump");
        //    jumpWait();
        //}
    }


}
