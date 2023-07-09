using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BeerScript : MonoBehaviour
{
    private const int LIFETIME = 125;
    private const int TIMEOUT = 100;


    [SerializeField]
    private GameObject uiBeerPrefab;
    private int timeout = 0;
    private int lifetime = LIFETIME;


    Queue<GameObject> spawnedBeers;
    // Start is called before the first frame update
    void Start()
    {
        spawnedBeers = new Queue<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeout != 0) timeout--;
        if(timeout == 0 && UnityEngine.Random.Range(0,3) == 1)
        {
            var newBeer = Instantiate(uiBeerPrefab, GenerateRandomSpawnPoint(), Quaternion.identity);
            spawnedBeers.Enqueue(newBeer);
            newBeer = Instantiate(uiBeerPrefab, GenerateRandomSpawnPoint(), Quaternion.identity);
            spawnedBeers.Enqueue(newBeer);
            timeout = TIMEOUT;
        }
        if(lifetime != 0) lifetime--;
        if(lifetime == 0 && spawnedBeers.Count > 0)
        {
            Destroy(spawnedBeers.Dequeue());
            Destroy(spawnedBeers.Dequeue());
            lifetime = LIFETIME;
        }
    }

    Vector3 GenerateRandomSpawnPoint()
    {
        return new Vector3(UnityEngine.Random.Range(-7,7), 5.0f + Random.Range(-0.5f, 0.5f), 0);
    }

    void FixedUpdate(){

    }
}
