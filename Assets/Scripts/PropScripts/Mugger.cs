using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Enums;
using PropScripts;
using UnityEngine;

public class Mugger : AbstractProp
{
    [SerializeField] private GameObject police;

    private Animator animator;
    private static readonly int Chased = Animator.StringToHash("Chased");
    
    public override int MoneyToRemove { get { return 20; } }
    public override int ToxicityDifference { get { return 5; } }
    public override int ScoreDifference { get { return -20; } }

    public override bool CanInteract() 
    {
        return gameManager.inventoryManager.UsingCurrently == ResourceType.Police;
    }

    public override void AttemptNeutralize()
    {
        GameObject officer = Instantiate(police);
        officer.transform.position = new Vector3(gameManager.playerPos.position.x + 10, transform.position.y, -1);
        officer.GetComponent<PoliceOfficerScript>().isPlacedByPlayer = true;
        animator.SetTrigger(Chased);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            ExecuteInteraction();
    }
}
