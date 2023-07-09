using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoliceResource : Resource
{
    private static PoliceResource instance;

    public PoliceResource(int numberOwned = 1) : base(numberOwned) 
    {
    }

    public static PoliceResource GetInstance()
    {
        if (instance != null)
            return instance;
        instance = new PoliceResource();
        return instance;
    }

    public override string InventoryTag()
    {
        return "PoliceInventory";
    }

}
