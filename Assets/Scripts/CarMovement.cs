using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        if(transform.position.y > 5){
            rb.velocity = new Vector2(0.0f, -((Time.frameCount * 0.01f) * 2.0f));
        }else if(transform.position.y < -5){
            rb.velocity = new Vector2(0.0f, -((Time.frameCount * 0.01f) * 2.0f));
        }else{
            rb.velocity = new Vector2(-(Time.frameCount * 0.01f) * 2.0f, 0.0f);
        }
    }
}
