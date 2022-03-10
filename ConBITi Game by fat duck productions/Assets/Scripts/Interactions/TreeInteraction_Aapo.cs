using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TreeInteraction_Aapo : Interactive
{
    [SerializeField]
    private GameObject Treestump;
    public GameObject axe;
    public GameObject pickaxe;
 

    public Animator runAnimator;

    private void Awake()
    {
       
    }

   
    public override void Interact()
    {
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
