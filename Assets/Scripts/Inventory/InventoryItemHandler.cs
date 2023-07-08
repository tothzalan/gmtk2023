using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Enums;

public class InventoryItemHandler : MonoBehaviour
{
    [SerializeField]
    public ResourceType resourceType;

    private Resource resource;

    private TextMeshProUGUI amountText;

    [SerializeField]
    public GameObject inventoryManagerGameObject;
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = inventoryManagerGameObject.GetComponent<InventoryManager>();
        switch(resourceType)
        {
            case ResourceType.Buoy:
                resource = BuoyResource.Init(5);
                break;
            case ResourceType.Water:
                resource = WaterResource.Init(7);
                break;
            case ResourceType.Police:
                resource = PoliceResource.Init(1);
                break;
            case ResourceType.Blackout:
                resource = BlackoutResource.Init(10);
                break;
        }
        amountText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        amountText.text = resource.NumberOwned.ToString();
    }

    void OnMouseDown()
    {
        if( resource.CanUseResource()
            && inventoryManager.UsingCurrently == ResourceType.None)
        {
            resource.UseResource();
            amountText.text = resource.NumberOwned.ToString();
            inventoryManager.UsingCurrently = resourceType;
        }
    }
}
