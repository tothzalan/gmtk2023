using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    private Rigidbody2D busRigidBody;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start(){
        busRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        busRigidBody.velocity = new Vector2(speed, 0.0f);
    }

    
}
