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
                resource = BuoyResource.GetInstance();
                break;
            case ResourceType.Police:
                resource = PoliceResource.GetInstance();
                break;
            case ResourceType.Blackout:
                resource = BlackoutResource.GetInstance();
                break;
        }
        amountText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        amountText.text = resource.NumberOwned.ToString();
    }

    public void Clicked()
    {
        if( resource.CanUseResource()
            && inventoryManager.UsingCurrently == ResourceType.None)
        {
            amountText.text = resource.NumberOwned.ToString();
            inventoryManager.UsingCurrently = resourceType;
        }
        else if(inventoryManager.UsingCurrently == resourceType)
        {
            amountText.text = resource.NumberOwned.ToString();
            inventoryManager.UsingCurrently = ResourceType.None;
        }
    }
}
