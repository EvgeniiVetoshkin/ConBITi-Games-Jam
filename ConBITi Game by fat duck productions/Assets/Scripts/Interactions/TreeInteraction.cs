using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Intaractive
{
    public override void Interacte()
    {
        Debug.Log(transform.name + " is made of " + transform.name + " here");
    }
}
