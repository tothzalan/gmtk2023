using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoliceResource : Resource
{
    private static PoliceResource instance;

    public PoliceResource(int numberOwned) : base(numberOwned) 
    {
    }

    public static PoliceResource GetInstance()
    {
        if(instance == null)
            throw new InvalidOperationException("You have to call the Init method first");
        return instance;
    }

    public static PoliceResource Init(int numberOwned)
    {
        if(instance != null)
            throw new InvalidOperationException("You have already initialized the Singleton");
        instance = new PoliceResource(numberOwned);
        return instance;
    }

    public override string InventoryTag()
    {
        return "PoliceInventory";
    }

}
