using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> inventoryGameObjects;
    private List<InventoryItemHandler> inventoryHandlers = new List<InventoryItemHandler>();

    // TODO: when placing down a resource update this to ResourceType.None
    private ResourceType usingCurrently = ResourceType.None;
    public ResourceType UsingCurrently { get { return usingCurrently; } set { usingCurrently = value; } }

    // Start is called before the first frame update
    void Start()
    {
        foreach(var inventoryGameObject in inventoryGameObjects)
        {
            inventoryHandlers.Add(inventoryGameObject.GetComponent<InventoryItemHandler>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
