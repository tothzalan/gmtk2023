using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class TrafficLight : AbstractProp
{
    public override bool CanInteract()
    {
        return true;
    }
    public override void AttemptNeutralize()
    {
        if(state == TrafficLightState.Green)
            state = TrafficLightState.Red;
        else if(state == TrafficLightState.Red)
            state = TrafficLightState.Green;
        ChangeState();
    }

    public override int MoneyToRemove { get { return 0; } }
    public override int ToxicityDifference { get { return 0; } }
    public override int ScoreDifference { get { return 0; } }


    public TrafficLightState state = TrafficLightState.Green;
    private Color red = new Color(255, 0, 0);
    private Color green = new Color(0, 255, 0);

    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;


    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        ChangeState();
    }

    void OnMouseDown()
    {
        AttemptNeutralize();
    }

    void ChangeState()
    {
        if(state == TrafficLightState.Green)
        {
            boxCollider.isTrigger = true;
            spriteRenderer.color = green;

        }
        else if(state == TrafficLightState.Red)
        {
            boxCollider.isTrigger = false;
            spriteRenderer.color = red;
        }
    }
}