using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using PropScripts;

public class ItemHandler : AbstractProp
{
    [SerializeField]
    public ResourceType resourceType;

    //TODO: no List
    [SerializeField]
    public List<Sprite> sprites;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;


    public override int MoneyToRemove { get { return 0; } }
    public override int ToxicityDifference { get { return 0; } }
    public override int ScoreDifference { get { return 15; } }
    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        switch(resourceType)
        {
            case ResourceType.Buoy:
                spriteRenderer.sprite = sprites[0];
                break;
            case ResourceType.Police:
                spriteRenderer.sprite = sprites[1];
                break;
            default:
                spriteRenderer.sprite = sprites[2];
                break;
        }
        gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
        boxCollider.size = new Vector2(5, 5);
    }

    public override bool CanInteract()
    {
        return true;
    }

    public override void AttemptNeutralize()
    {
        Resource instance;
        switch(resourceType)
        {
            case ResourceType.Buoy:
                instance = BuoyResource.GetInstance();
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
