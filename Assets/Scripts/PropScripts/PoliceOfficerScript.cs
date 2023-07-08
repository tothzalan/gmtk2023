using System;
using System.Collections;
using System.Collections.Generic;
using PropScripts;
using UnityEngine;

public class PoliceOfficerScript : AbstractProp
{
    [NonSerialized]
    public bool isPlacedByPlayer;

    private Rigidbody2D rigidBody;
    public override bool CanInteract()
    {
        return true;
    }

    protected override void TriggerStart()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isPlacedByPlayer)
        {
            rigidBody.velocity = new Vector2(2.0f, 0);
        }
    }

    public override void AttemptNeutralize()
    {
    }

    public override int MoneyToRemove { get; }
    public override int ToxicityDifference { get; }
    public override int ScoreDifference { get; } = 20;

}
