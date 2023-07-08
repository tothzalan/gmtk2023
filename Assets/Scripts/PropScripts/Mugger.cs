using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugger : AbstractProp
{
    public override int MoneyToRemove { get { return 20; } }
    public override int ToxicityDifference { get { return 5; } }
    public override int ScoreDifference { get { return -20; } }

    public override bool CanInteract() 
    {
        return false;
    }

    public override void AttemptNeutralize()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            ExecuteInteraction();
        }
    }
}
