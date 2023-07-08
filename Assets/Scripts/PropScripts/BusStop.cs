using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropScripts;

public class BusStopScript : AbstractProp
{
    public GameObject busPrefab;
    private Vector2 spawnPos;
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
        return true;
    }

    public override void AttemptNeutralize(){
        //TODO: Regenerate Map
        GameObject bus = Instantiate(busPrefab) as GameObject;
        bus.transform.position = new Vector2((spawnPos.x-10), spawnPos.y);
        
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
