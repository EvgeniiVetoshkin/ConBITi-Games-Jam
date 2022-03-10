using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Intaractive
{
    [SerializeField]
    private GameObject stump;
    WorldHandler wh;

    private void Awake()
    {
        wh = FindObjectOfType<WorldHandler>();
    }
    public override void Interacte()
    {
        Debug.Log(transform.name + " interaction ");

        Instantiate(stump, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
