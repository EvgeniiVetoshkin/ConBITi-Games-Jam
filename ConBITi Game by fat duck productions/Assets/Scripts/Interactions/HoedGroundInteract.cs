using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoedGroundInteract : Interactive
{

    
    private WheatGrow wG;


    public override void Init()
    {
        
        wG = GetComponent<WheatGrow>();
    }

    public override void Interact()
    {
        if (!wG.planted)
        {
            wG.Plant();
        }
        else if (wG.growed)
        {
            wG.Harvest();
        }

    }
}
