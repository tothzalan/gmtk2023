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
    protected override void TriggerStart()
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
            return false;
        } 
        Debug.Log(playerPrefab.transform.position.x);
        if((spawnPos.x - playerPrefab.transform.position.x) < 3){
            isPressed++;
            return true;
        }else{
            return false;
        }
    }

    public override void AttemptNeutralize(){
        //TODO: Regenerate Map
        GameObject bus = Instantiate(busPrefab);
        bus.transform.position = new Vector2((-20), spawnPos.y-4);
        mapGenerator.ReloadPlatforms();
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
