using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheatGrow : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private float maxSecondsToGrow = 10;

    public bool planted { get; set;}
   
    public bool growed { get; set; }

    [SerializeField]
    [Range(1, 100)]
    private float minSecondsToGrow = 5;

    [SerializeField]
    private GameObject wheatPref;
    private GameObject wheat;

    private Material mat;

    //private Material mat;


    private void Start()
    {
        if (minSecondsToGrow > maxSecondsToGrow)
        {
            float tmp = minSecondsToGrow;
            minSecondsToGrow = maxSecondsToGrow;
            maxSecondsToGrow = tmp;
            Debug.LogError("Dawn?");
        }
        mat = GetComponent<Renderer>().material;

        //mat = GetComponent<Material>();
    }
    private IEnumerator Grow()
    {
        yield return new WaitForSeconds(Random.Range(0, maxSecondsToGrow));

        wheat = Instantiate(wheatPref, transform);
        mat.color /= 0.8f;
        growed = true;
    }

    public void Plant()
    {
        planted = true;
        growed = false;
        mat.color *= 0.8f;
        StartCoroutine(Grow());
    }

    public void Harvest()
    {
        planted = false;
        Destroy(wheat);
    }

}
