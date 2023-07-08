using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropScripts;

public class BusStopScript : AbstractProp
{
    public GameObject busPrefab;
    public GameObject playerPrefab;
    public Vector2 spawnPos;
    private int isPressed;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        playerPrefab = GameObject.FindWithTag("Player");
        isPressed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CanInteract(){
        if(isPressed == 1){
            Debug.Log("Nem nyomhatod meg tobbszor!");
            return false;
        } 
        Debug.Log(playerPrefab.transform.position.x);
        if((spawnPos.x - playerPrefab.transform.position.x) < 1){
            isPressed++;
            return true;
        }else{
            return false;
        }
    }

    public override void AttemptNeutralize(){
        //TODO: Regenerate Map
        GameObject bus = Instantiate(busPrefab) as GameObject;
        bus.transform.position = new Vector2((spawnPos.x-15), spawnPos.y-1.5f);
        
    }

    public override int MoneyToRemove{
        get;
    }

    public override int ScoreDifference{
        get;
    }

    public override int ToxicityDifference{
        get;
    }
}
