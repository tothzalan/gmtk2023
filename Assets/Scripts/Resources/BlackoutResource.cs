using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlackoutResource : Resource
{
    private static BlackoutResource instance;

    public BlackoutResource(int numberOwned) : base(numberOwned) 
    {
    }

    public static BlackoutResource GetInstance()
    {
        if(instance == null)
            throw new InvalidOperationException("You have to call the Init method first");
        return instance;
    }

    public static BlackoutResource Init(int numberOwned)
    {
        if(instance != null)
            throw new InvalidOperationException("You have already initialized the Singleton");
        instance = new BlackoutResource(numberOwned);
        return instance;
    }

    public override string InventoryTag()
    {
        return "BlackoutInventory";
    }
}
