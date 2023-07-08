using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuoyResource : Resource
{
    private static BuoyResource instance;

    public BuoyResource(int numberOwned) : base(numberOwned) 
    {
    }

    public static BuoyResource GetInstance()
    {
        if(instance == null)
            throw new InvalidOperationException("You have to call the Init method first");
        return instance;
    }

    public static BuoyResource Init(int numberOwned)
    {
        if(instance != null)
            throw new InvalidOperationException("You have already initialized the Singleton");
        instance = new BuoyResource(numberOwned);
        return instance;
    }

    public override string InventoryTag()
    {
        return "BuoyInventory";
    }
}
