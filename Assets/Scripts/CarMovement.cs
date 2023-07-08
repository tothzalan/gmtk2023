using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Vector2 spawnPos;
    private bool isCollided;
    public float ySpeed = 5.0f;
    public Rigidbody2D rb;
    float scaleY;

    // Start is called before the first frame update
    void Start()
    {
        isCollided = false;
        spawnPos = transform.position;
        scaleY = transform.localScale.y;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollided == false){
            if(spawnPos.y > 5){
                rb.velocity = new Vector2(0.0f, -ySpeed);
                transform.localScale = new Vector2(transform.localScale.x, (-1)*scaleY);
            }
            else if(spawnPos.y < -2){
                rb.velocity = new Vector2(0.0f, ySpeed);
                transform.localScale = new Vector2(transform.localScale.x, scaleY);
            }        
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        rb.velocity = Vector2.zero;
        isCollided = true;
    }

}
