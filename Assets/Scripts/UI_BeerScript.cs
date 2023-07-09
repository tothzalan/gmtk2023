using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BeerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject uiBeerPrefab;
    private int timeout = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomSpawnPoint = new Vector3(UnityEngine.Random.Range(-7,7), UnityEngine.Random.Range(5.0f,8.0f), 0);
        if(timeout != 0){
            timeout--;
        }
        if(timeout == 0 && UnityEngine.Random.Range(0,3) == 1){
            Instantiate(uiBeerPrefab, randomSpawnPoint, Quaternion.identity);
            timeout = 360;
        }
    }

    void FixedUpdate(){

    }
}
