using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CarMovement : MonoBehaviour
{
    private Vector2 spawnPos;
    private Rigidbody2D rigidBody;
    public float speed = 5.0f;
    private int lifetime = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        lifetime++;
        if(lifetime == 15000){
            Destroy(gameObject);
        }
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(speed, 0);
    }
}
