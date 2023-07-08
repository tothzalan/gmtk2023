using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{   
    [SerializeField]
    public GameObject objPrefab;

    [SerializeField]
    public float;

    [SerializeField]
    public SpawnerY;

    private PlayerMovement player;



    void Start(){
        SpawnerY = 0;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnVector = new Vector3(player.xAxisPlayer+2, SpawnerY ,0);
        Instantiate(objPrefab, spawnVector, Quaternion.identity);
    }

    void SpawnObject(){
        GameObject newObject = Instantiate(objPrefab);
    }
}
