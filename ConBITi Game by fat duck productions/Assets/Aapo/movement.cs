using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class movement : MonoBehaviour
{
    public CharacterController charcon;
    public float speed = 6;
    public float jumpSpeed = 5;
    public CinemachineFollowZoom cmfz;
    public Rigidbody rb;
    public Vector3 jump;
    public bool canjump;



 
    private IEnumerator ZoomWait()
    {
        cmfz.m_MinFOV = 5f;
        yield return new WaitForSeconds(5f);
        cmfz.m_MinFOV = 60f;
    }

    private IEnumerator JumpCd()
    {
        canjump = false;
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y - 2, transform.localPosition.z);
        canjump = true;
    }

    private void Awake()
    {
        jump = new Vector3(0, 2, 0);
        canjump = true;
    }



    void Update()
    {
        Move();

        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine("ZoomWait");
            }

            if (Input.GetKey(KeyCode.Space) && canjump == true)
            {
                canjump = true;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+2, transform.localPosition.z);
                StartCoroutine("JumpCd");




            }
        }
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        charcon.Move(speed * Time.deltaTime * move);
    }

}
