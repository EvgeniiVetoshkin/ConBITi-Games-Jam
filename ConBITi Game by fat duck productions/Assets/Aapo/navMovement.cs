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
    public Animator runAnimator;

        public GameObject clickloc;
    public GameObject player;
    public float time;
    public GameObject axe;
    public GameObject pickaxe;

    private Transform cuttableTree;
    public GameObject inventory;

    private void Awake()
    {
  
        _Agent = GetComponent<NavMeshAgent>();

        runAnimator.SetBool("afk", true);
        runAnimator.SetBool("walk", false);
        runAnimator.SetBool("cut", false);


    }


    private IEnumerator ZoomWait()
    {
        cmfz.m_MinFOV = 5f;
        yield return new WaitForSeconds(5f);
        cmfz.m_MinFOV = 60f;
    }

    
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            inventory.SetActive(false);
        }




        if (player.transform.position.x == clickloc.transform.position.x && player.transform.position.z == clickloc.transform.position.z)
        {
            runAnimator.SetBool("afk", true);
            runAnimator.SetBool("walk", false);
            
        }


        if (player.transform.position.x != clickloc.transform.position.x && player.transform.position.z != clickloc.transform.position.z)
        {
            runAnimator.SetBool("afk", false);
            runAnimator.SetBool("walk", true);
            runAnimator.SetBool("cut", false);
            axe.SetActive(false);
            pickaxe.SetActive(false);
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

                Vector3 distanceToWalkPoint = transform.position - hit.point;


            }

        }

        
        
       

       
    }
  


   



}
