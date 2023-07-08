using UnityEngine;
using Enums;

namespace PropScripts
{
    public class DealerProp : AbstractProp
    {
        public override int MoneyToRemove { get; } = 30;
        public override int ToxicityDifference { get; } = 20;
        public override int ScoreDifference { get; } = -50;

        public override bool CanInteract()
        {
            return gameManager.inventoryManager.UsingCurrently == ResourceType.Police;
        }

        public override void AttemptNeutralize()
        {
            gameManager.inventoryManager.UsingCurrently = ResourceType.None;
            Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player")
                ExecuteInteraction();
        }
    }
}