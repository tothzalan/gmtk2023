using System.Collections;
using System.Collections.Generic;
using Enums;
using PropScripts;
using UnityEngine;

public class Mugger : AbstractProp
{
    public override int MoneyToRemove { get { return 20; } }
    public override int ToxicityDifference { get { return 5; } }
    public override int ScoreDifference { get { return -20; } }

    public override bool CanInteract() 
    {
        Debug.Log($"CanInteract: {gameManager.inventoryManager.UsingCurrently == ResourceType.Police} {gameManager.inventoryManager.UsingCurrently}");
        return gameManager.inventoryManager.UsingCurrently == ResourceType.Police;
    }

    public override void AttemptNeutralize()
    {
        gameManager.inventoryManager.UsingCurrently = ResourceType.None;
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            ExecuteInteraction();
    }
}
