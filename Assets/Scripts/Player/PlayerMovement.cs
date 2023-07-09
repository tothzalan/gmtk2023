using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animation;
    public GameObject carPrefab;

    private float maxSpeed = 15f;
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

    void OnTriggerEnter2D(Collider2D col){
        var colTag = col.tag;
        if(!gameManager.Dead)
        {
            if(colTag == "EnterCol")
            {
                inCollision = true;
                gameObject.transform.position =
                    Vector2.Lerp(
                        gameObject.transform.position, 
                        new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 5),
                        Time.deltaTime * 10);
            }

            else if(colTag == "ExitCol")
            {
                inCollision = true;
                gameObject.transform.position =
                    Vector2.Lerp(
                        gameObject.transform.position, 
                        new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 5),
                        Time.deltaTime * 10);
            }
            else if(colTag == "Car")
            {
                gameManager.killedBy = "Car";
                gameManager.Dead = true;
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "ExitCol") 
            inCollision = false;
    }
}