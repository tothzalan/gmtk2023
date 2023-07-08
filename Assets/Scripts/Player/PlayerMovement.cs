using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private bool isCollided;
    
    public GameObject carPrefab;
    //private float speed = 8f;

    private Rigidbody2D rb;
    private GameManager gm;
    //private CarMovement cm;
    //private Spawner spawn;

    public float xAxisPlayer;
    public float ySpawn;
    public bool triggerEvent;

    private bool dead = false;

    void Start() {
        isCollided = false;
        triggerEvent = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
      //spawn = GameObject.FindWithTag("SpawnTag").GetComponent<Spawner>();
        //cm = GameObject.FindWithTag("Car").GetComponent<CarMovement>();
    }

    private void FixedUpdate(){
        if(!isCollided && !dead){
            if(!triggerEvent){
                rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
                xAxisPlayer = rb.position.x; 
            }else{
                rb.velocity = new Vector2(0.0f, 0.0f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        var colTag = col.tag;
        //Debug.Log("Fasz vagy");
        if(!dead)
        {
            if(colTag == "EnterCol")
            {
                isCollided = true;
                rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), -0.8f);
                GameObject car = Instantiate(carPrefab) as GameObject;
                //Debug.Log(car.position.x);
                car.transform.position = new Vector2(xAxisPlayer+2, 0.0f);            
            }
            else if(colTag == "StayCol")
            {
                isCollided = true;
                rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
            }
            else if(colTag == "ExitCol")
            {
                isCollided = true;
                rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.8f);
            }
            else if(colTag == "Car")
            {
                // TODO: play cool death animation
                rb.velocity = new Vector2(0, 0);
                gm.Dead = true;
                dead = true;
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        var colTag = col.tag;       
        if(colTag == "EnterCol"){
            isCollided = false;
            Debug.Log("Faszszopo vagy");

        }else if(colTag == "ExitCol"){
            isCollided = false;
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
        }else if(colTag == "StayCool"){
            isCollided = false;
        }
    }
}