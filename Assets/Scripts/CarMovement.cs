using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class CarMovement : MonoBehaviour
{
    private Vector2 spawnPos;
    private GameObject playerPrefab;
    private GameObject carPrefab;
    public Rigidbody2D rigidBody;
    public float speed = 5.0f;
    private int timeout;
    private int lifetime;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerPrefab = GameObject.FindWithTag("Player");
        carPrefab = GameObject.FindWithTag("Car");
        timeout = 720;
        lifetime = 0;
    }

    void Update(){
        Vector3 randomSpawnPoint = new Vector3(playerPrefab.transform.position.x-30.0f, Random.Range(-1,1),0);
        if(timeout != 0){
            timeout--;
        }
        if(timeout == 0 && Random.Range(0, 3000) == 1){
            Instantiate(carPrefab, randomSpawnPoint, Quaternion.identity);
            timeout = 720;
        }
        lifetime++;
        if(lifetime == 5000){
            Destroy(carPrefab);
        }
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(speed, 0);
    }
}
