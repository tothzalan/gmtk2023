using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Resource : MonoBehaviour
{

    private int numberOwned = 0;

    public int NumberOwned { get { return numberOwned; } }


    public virtual void UseResource()
    {
        numberOwned -= 1;
    }

    public bool CanUseResource()
    {
        return numberOwned > 0;
    }

    public Resource(int numberOwned)
    {
        this.numberOwned = numberOwned;
    }

}
