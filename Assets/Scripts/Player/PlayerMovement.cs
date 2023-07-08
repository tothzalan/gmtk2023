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

    void Start() {
        isCollided = false;
        triggerEvent = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
      //spawn = GameObject.FindWithTag("SpawnTag").GetComponent<Spawner>();
        //cm = GameObject.FindWithTag("Car").GetComponent<CarMovement>();
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
        //Debug.Log("Fasz vagy");
        if(a == "EnterCol")
        {
            isCollided = true;
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), -0.8f);
            GameObject car = Instantiate(carPrefab) as GameObject;
            //Debug.Log(car.position.x);
            car.transform.position = new Vector2(xAxisPlayer+2, 0.0f);            
        }
        else if(a == "StayCol")
        {
            isCollided = true;
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
        }
        else if(a == "ExitCol")
        {
            isCollided = true;
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.8f);
        }
        else if(a == "Car")
        {
            // TODO: play cool death animation
            rb.velocity = new Vector2(0, 0);
            gm.Dead = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        var a = col.tag;       
        if(a == "EnterCol"){
            isCollided = false;
            Debug.Log("Faszszopo vagy");

        }else if(a == "ExitCol"){
            isCollided = false;
            rb.velocity = new Vector2(((gm.SpeedMultiplier+1) * 0.1f), 0.0f);
        }else if(a == "StayCool"){
            isCollided = false;
        }
    }
}