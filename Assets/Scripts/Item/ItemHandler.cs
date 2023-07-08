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
        
        switch(resourceType)
        {
            case ResourceType.Buoy:
                Resource instance = BuoyResource.GetInstance();
                instance.AddAmount(1);
                break;
        }
    }
}
