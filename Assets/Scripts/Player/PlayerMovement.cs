using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animation;
    public GameObject carPrefab;

    private float maxSpeed = 10f;
    [SerializeField]
    private float speed;

    private Rigidbody2D rigidBody;
    private GameManager gameManager;

    private bool inCollision = false;

    void Start() {
        speed = 2.5f;
        animation.enabled = true;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void FixedUpdate(){
        if(speed < maxSpeed){
            speed += 0.01f*Time.deltaTime;
        }
        if (gameManager.Dead)
        {
            rigidBody.velocity = Vector2.zero;
            animation.enabled = false;
        }
        else if(!inCollision)
        {
            rigidBody.velocity = new Vector2(speed, 0.0f);
        }
    }
    
}