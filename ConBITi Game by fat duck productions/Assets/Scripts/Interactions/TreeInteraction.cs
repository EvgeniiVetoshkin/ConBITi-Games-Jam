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

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public override void Interact()
    {

        if (anim.isPlaying)
        {
            return;
        }

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
