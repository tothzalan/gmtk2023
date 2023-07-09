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

    private Rigidbody2D rigidBody;
    private GameManager gameManager;

    private bool inCollision = false;

    void Start() {
        gameManager.Speed = 2.5f;
        animation.enabled = true;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void FixedUpdate(){
        if(gameManager.Speed < maxSpeed){
            gameManager.Speed += 0.01f*Time.deltaTime;
        }
        if (gameManager.Dead)
        {
            rigidBody.velocity = Vector2.zero;
            animation.enabled = false;
        }
        else if(!inCollision)
        {
            rigidBody.velocity = new Vector2(gameManager.Speed, 0.0f);
        }
    }
    
}