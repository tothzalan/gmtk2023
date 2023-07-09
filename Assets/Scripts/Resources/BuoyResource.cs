using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuoyResource : Resource
{
    private static BuoyResource instance;

    public BuoyResource(int numberOwned = 5) : base(numberOwned) 
    {
    }

    public static BuoyResource GetInstance()
    {
        if (instance != null)
            return instance;
        instance = new BuoyResource();
        return instance;
    }

    public override string InventoryTag()
    {
        return "BuoyInventory";
    }
}
