using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class ItemHandler : MonoBehaviour
{
    [SerializeField]
    public ResourceType resourceType;

    //TODO: no List
    [SerializeField]
    public List<Sprite> sprites;

    private SpriteRenderer spriteRenderer;

    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch(resourceType)
        {
            case ResourceType.Buoy:
                spriteRenderer.sprite = sprites[0];
                break;
            case ResourceType.Water:
                spriteRenderer.sprite = sprites[1];
                break;
            case ResourceType.Police:
                spriteRenderer.sprite = sprites[2];
                break;
            default:
                spriteRenderer.sprite = sprites[3];
                break;
        }
        gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
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
        GameObject.Destroy(gameObject);
    }
}
