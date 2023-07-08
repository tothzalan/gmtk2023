using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class ItemHandler : MonoBehaviour
{
    [SerializeField]
    public ResourceType resourceType;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        GameObject.Destroy(gameObject);
        
        Resource instance;
        switch(resourceType)
        {
            case ResourceType.Buoy:
                instance = BuoyResource.GetInstance();
                break;
            case ResourceType.Water:
                instance = WaterResource.GetInstance();
                break;
            case ResourceType.Police:
                instance = PoliceResource.GetInstance();
                break;
            default:
                instance = BlackoutResource.GetInstance();
                break;
        }
        instance.AddAmount(1);
    }
}
