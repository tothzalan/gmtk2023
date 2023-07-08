using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropScripts;

public class BusStopScript : AbstractProp
{
    public GameObject busPrefab;
    public Vector2 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CanInteract(){
        /*if((spawnPos.x - gameManager.playerPos.position.x) < 5){
            return true;
        }else{
            return false;
        }*/
        return true;
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
