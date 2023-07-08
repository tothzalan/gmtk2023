using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private bool isCollided;
    //private float speed = 8f;

    private Rigidbody2D rb;
    private GameManager gm;
    private CarMovement cm;
    //private Spawner spawn;

    public float xAxisPlayer;
    public float ySpawn;
    public bool triggerEvent;

    void Start() {
        isCollided = false;
        triggerEvent = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
      //spawn = GameObject.FindWithTag("SpawnTag").GetComponent<Spawner>();
        //cm = GameObject.FindWithTag("Car");
    }

    private void FixedUpdate(){
        if(isCollided == false){
            if(triggerEvent == false){
                rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
                xAxisPlayer = rb.position.x; 
            }else{
                rb.velocity = new Vector2(0.0f, 0.0f);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col){
        var a = col.tag;
        Debug.Log("Fasz vagy");
        isCollided = true;
        if(a == "EnterCol"){
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), -1.0f);
        }else if(a == "StayCol"){
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
        }else if(a == "ExitCol"){
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 1.0f);
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        var a = col.tag;
        /*
        if(a == "EnterCol"){
            //Instantiate(cm, new Vector3(xAxisPlayer+2, ySpawn, 0));
        }else if(a == "ExitCol"){
            isCollided = false;
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
        }*/
    }
}