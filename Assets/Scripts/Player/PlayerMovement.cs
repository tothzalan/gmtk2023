using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    //private float speed = 8f;

    private Rigidbody2D rb;

    public bool triggerEvent;

    void Start() {
        triggerEvent = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector2(0,1));
        
        
    }

    private void FixedUpdate(){
        if(triggerEvent == false){
            rb.velocity = new Vector2((Time.frameCount * 0.001f) * 2.0f, 0.0f);
        }else{
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}