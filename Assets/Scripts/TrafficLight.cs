using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class TrafficLight : MonoBehaviour
{
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
        if(state == TrafficLightState.Green)
            state = TrafficLightState.Red;
        else if(state == TrafficLightState.Red)
            state = TrafficLightState.Green;
        ChangeState();
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
