using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Resource
{
    protected int numberOwned = 0;

    public int NumberOwned { get { return numberOwned; } }

    public virtual void UseResource()
    {
        if(CanUseResource())
        {
            numberOwned -= 1;
            ChangeInventoryAmount();
        }
    }

    public void AddAmount(int amount)
    {
        numberOwned += amount;
        ChangeInventoryAmount();
    }

    public bool CanUseResource()
    {
        return numberOwned > 0;
    }

    public Resource(int numberOwned)
    {
        this.numberOwned = numberOwned;
    }

    public virtual string InventoryTag()
    {
        return "";
    }

    private void ChangeInventoryAmount()
    {
        var inventoryItem = GameObject.FindWithTag(InventoryTag()).GetComponentInChildren<TextMeshProUGUI>();
        inventoryItem.text = numberOwned.ToString();
    }

}

