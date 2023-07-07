using System;
using System.Collections;
using System.Collections.Generic;
using PropScripts;
using UnityEngine;

public abstract class AbstractProp : MonoBehaviour
{
    protected GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.FindWithTag("GameController"); // TODO game controller object
        gameManager = manager.GetComponent<GameManager>();
        TriggerStart();
    }
    private void OnMouseUpAsButton()
    {
        AttemptNeutralize();
    }
    
    public void ExecuteInteraction()
    {
        gameManager.AddMoney(MoneyDifference);
        gameManager.AddToxicity(ToxicityDifference);
    }

    protected virtual void TriggerStart()
    {
        
    }
    public abstract void AttemptNeutralize();
    public abstract int MoneyDifference { get; }
    public abstract int ToxicityDifference { get; }

    
}
