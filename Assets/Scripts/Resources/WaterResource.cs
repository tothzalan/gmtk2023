using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaterResource : Resource
{
    private static WaterResource instance;

    public WaterResource(int numberOwned) : base(numberOwned) 
    {
    }

    public static WaterResource GetInstance()
    {
        if(instance == null)
            throw new InvalidOperationException("You have to call the Init method first");
        return instance;
    }

    public static WaterResource Init(int numberOwned)
    {
        if (instance != null)
            return instance;
        instance = new WaterResource(numberOwned);
        return instance;
    }

    public override string InventoryTag()
    {
        return "WaterInventory";
    }
}