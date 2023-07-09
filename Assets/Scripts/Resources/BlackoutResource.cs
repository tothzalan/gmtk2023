using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlackoutResource : Resource
{
    private static BlackoutResource instance;

    public BlackoutResource(int numberOwned = 10) : base(numberOwned) 
    {
    }

    public static BlackoutResource GetInstance()
    {
        if (instance != null)
            return instance;
        instance = new BlackoutResource();
        return instance;
    }

    public override string InventoryTag()
    {
        return "BlackoutInventory";
    }
}
