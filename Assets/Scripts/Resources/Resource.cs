using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Resource : MonoBehaviour
{

    protected int numberOwned = 0;

    public int NumberOwned { get { return numberOwned; } }


    public virtual void UseResource()
    {
        if(CanUseResource())
            numberOwned -= 1;
    }

    public void AddAmount(int amount)
    {
        numberOwned += amount;
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
