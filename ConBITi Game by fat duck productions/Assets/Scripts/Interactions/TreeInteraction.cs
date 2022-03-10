using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TreeInteraction : Interactive
{
    //[SerializeField]
    //private GameObject stump;
    
    private Animation anim;

    [SerializeField]
    [Range(1, 5)]
    int hitsToChop;
    int performedHits;

    private AnimationClip[] animclips;


    private GameObject axe;
    private GameObject pickaxe;
    private Animator runAnimator;


    private void Awake()
    {
        anim = GetComponent<Animation>();
        
        axe = GameObject.FindGameObjectWithTag("Axe");
        pickaxe = GameObject.FindGameObjectWithTag("Pickaxe");
        runAnimator = GameObject.FindGameObjectWithTag("PlayerAnimator").GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (anim.isPlaying)
        {
            return;
        }

        axe.SetActive(true);
        pickaxe.SetActive(false);
        Debug.Log(transform.name + " interaction ");
        runAnimator.SetBool("afk", false);
        runAnimator.SetBool("walk", false);
        runAnimator.SetTrigger("CutTrigger");

        performedHits++;
        if (performedHits == hitsToChop)
        {
            
            StartCoroutine(Chop());

        }
        else if (performedHits < hitsToChop)
        {
            anim.Play("TreeHit");
        }
    }

    private IEnumerator Chop()
    {

        Debug.Log(transform.name + " interaction ");


        anim.Play("TreeFall");

        yield return new WaitUntil(()=>!anim.isPlaying);

        //Instantiate(stump, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
