using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animation;
    public GameObject carPrefab;
    [SerializeField]
    private float speed = 8f;

    private Rigidbody2D rigidBody;
    private GameManager gameManager;

    private bool inCollision = false;
    private bool dead = false;

    void Start() {
        animation.enabled = true;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void FixedUpdate(){
        if (dead)
        {
            rigidBody.velocity = Vector2.zero;
            animation.enabled = false;
        }
        else if(!inCollision)
        {
            rigidBody.velocity = new Vector2(((gameManager.SpeedMultiplier+1) * speed)*1.0f, 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        var colTag = col.tag;
        if(!dead)
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
                dead = true;
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