using System;
using System.Collections;
using System.Collections.Generic;
using PropScripts;
using UnityEngine;

public abstract class AbstractProp : MonoBehaviour
{
    protected GameManager gameManager;

    [NonSerialized]
    public bool hasNeutralized;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        TriggerStart();
    }
    private void OnMouseUpAsButton()
    {
        AttemptNeutralize();
    }

    public virtual void ExecuteInteraction()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        if (!CanInteract())
            return;
        gameManager.RemoveMoney(MoneyToRemove);
        gameManager.AddToxicity(ToxicityDifference);
        gameManager.AddScore(ScoreDifference);
    }

    public void FinalizeNeutralization()
    {
        hasNeutralized = true;
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    protected virtual void TriggerStart()
    {
        
    }

    public abstract bool CanInteract();
    public abstract void AttemptNeutralize();
    public abstract int MoneyToRemove { get; }
    public abstract int ToxicityDifference { get; }
    public abstract int ScoreDifference { get; }
}
