using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.Animations;


public class navMovement : MonoBehaviour
{
    public NavMeshAgent _Agent;
    public Camera cam;
    public NavMeshAgent agent;
    public CinemachineFollowZoom cmfz;
   public Rigidbody rb;
    public Animator m_Animator;
    public GameObject clickloc;
    public GameObject player;
    public float time;


    private void Awake()
    {
        //rb.maxAngularVelocity = 0;
        _Agent = GetComponent<NavMeshAgent>();
        //m_Animator.SetBool("afk", true);
        m_Animator.SetBool("afk", true);
        m_Animator.SetBool("walk", false);

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
    public void Update()
    {

        if (player.transform.position.x == clickloc.transform.position.x && player.transform.position.z == clickloc.transform.position.z)
        {
            m_Animator.SetBool("afk", true);
            m_Animator.SetBool("walk", false);
        }


        if (player.transform.position.x != clickloc.transform.position.x && player.transform.position.z != clickloc.transform.position.z)
        {
            m_Animator.SetBool("afk", false);
            m_Animator.SetBool("walk", true);
        }


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
                clickloc.transform.position = hit.point;
                //Instantiate(clickloc, hit.point, transform.rotation);
                //StartCoroutine("clickSpawn");
                //Destroy(clickloc);
                Vector3 distanceToWalkPoint = transform.position - hit.point;



                //if (distanceToWalkPoint.magnitude <= 1f)
                //{
                //    m_Animator.SetBool("afk", true);
                //    m_Animator.SetBool("walk", false);
                //}

                //if (distanceToWalkPoint.magnitude > 1f)
                //{
                //    m_Animator.SetBool("afk", false);
                //    m_Animator.SetBool("walk", true);
                //}

            }

        }

        
        


        //if(rb.velocity == Vector3.zero)
        //{
        //    m_Animator.SetBool("ifWalking", false);

        //}

        //if(rb.velocity != Vector3.zero)
        //{
        //    m_Animator.SetBool("ifWalking", true);
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Debug.Log("jump");
        //    jumpWait();
        //}
    }

    //public IEnumerator clickSpawn()
    //{
        
    //    yield return new WaitForSeconds(3f);
        

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    collid
    //}



}
