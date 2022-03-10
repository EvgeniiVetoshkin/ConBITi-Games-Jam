using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TreeInteraction_Aapo : Intaractive
{
    [SerializeField]
    private GameObject Treestump;
    WorldHandler wh;
    public GameObject axe;
    public GameObject pickaxe;
    private Transform playerPosition;
    public Transform center;


    public Animator runAnimator;

    private void Awake()
    {
        wh = FindObjectOfType<WorldHandler>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    public override void Interacte()
    {
        playerPosition.LookAt(center);
        //FaceTarget();
        axe.SetActive(true);
        pickaxe.SetActive(false);
        Debug.Log(transform.name + " interaction ");
        runAnimator.SetBool("afk", true);
        runAnimator.SetBool("walk", false);
        runAnimator.SetBool("cut", true);
        Instantiate(Treestump, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }

    
   
}
