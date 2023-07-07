using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicityResource : Resource
{

    public ToxicityResource(int numberOwned) : base(numberOwned) 
    {
    }


    public bool IsDead()
    {
        return numberOwned >= 100;
    }

}
