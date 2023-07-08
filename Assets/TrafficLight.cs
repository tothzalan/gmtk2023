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


    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    void OnMouseDown()
    {
        if(state == TrafficLightState.Green)
        {
            state = TrafficLightState.Red;
        }
        else if(state == TrafficLightState.Red)
        {
            state = TrafficLightState.Green;
        }
        ChangeColor();
    }

    void ChangeColor()
    {
        if(state == TrafficLightState.Green)
            spriteRenderer.color = green;
        else if(state == TrafficLightState.Red)
            spriteRenderer.color = red;
    }
}
