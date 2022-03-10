using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TreeInteraction : Intaractive
{
    [SerializeField]
    private GameObject Treestump;
    WorldHandler wh;
    public GameObject axe;
    public GameObject pickaxe;
 

    public Animator runAnimator;

    private void Awake()
    {
        wh = FindObjectOfType<WorldHandler>();
        
    }

   
    public override void Interacte()
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
