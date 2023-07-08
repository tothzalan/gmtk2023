using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Vector2 spawnPos;
    private bool isCollided;
    public float speed = 5.0f;
    public Rigidbody2D rigidBody;
    float scaleY;

    // Start is called before the first frame update
    void Start()
    {
        isCollided = false;
        spawnPos = transform.position;
        scaleY = transform.localScale.y;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(speed, 0);
        /*
        if(isCollided == false){
            if(spawnPos.y > 5){
                rigidBody.velocity = new Vector2(0.0f, -ySpeed);
                transform.localScale = new Vector2(transform.localScale.x, (-1)*scaleY);
            }
            else if(spawnPos.y < -2){
                rigidBody.velocity = new Vector2(0.0f, ySpeed);
                transform.localScale = new Vector2(transform.localScale.x, scaleY);
            }else if(spawnPos.y == 0.5){
                rigidBody.velocity = new Vector2(15.0f, 0.0f);
                transform.localScale = new Vector2(transform.localScale.x, scaleY);
            }
        }
        */
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "TrafficCollider")
        {
            rigidBody.velocity = Vector2.zero;
            isCollided = true;
        }
    }

}
