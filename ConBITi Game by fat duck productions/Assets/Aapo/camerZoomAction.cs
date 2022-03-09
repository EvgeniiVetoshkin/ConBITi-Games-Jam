using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camerZoomAction : MonoBehaviour
{
    public CinemachineFollowZoom cmfz;

    private IEnumerator ZoomWait()
    {
        cmfz.m_MinFOV = 5f;
        yield return new WaitForSeconds(5f);
        cmfz.m_MinFOV = 60f;
    }

    // Update is called once per frame
    void Update()


    { 
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine("ZoomWait");
        }
    }

   

   
}
