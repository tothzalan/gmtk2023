using Enums;
using UnityEngine;

namespace PropScripts
{
    public class CarProp : AbstractProp
    {

        public GameObject buoy;
        public override bool CanInteract()
        {
            return gameManager.inventoryManager.UsingCurrently == ResourceType.Buoy;
        }

        public override void AttemptNeutralize()
        {
            Instantiate(buoy, new Vector3(transform.position.x, transform.position.y - 5), new Quaternion(0, 0, 0, 0));
            
            ExecuteInteraction();
        }

        protected override void TriggerCollisionPlayer()
        {
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; } = 20;
    }
}