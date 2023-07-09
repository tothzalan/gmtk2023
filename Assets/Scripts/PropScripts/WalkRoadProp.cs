using Enums;
using UnityEngine;

namespace PropScripts
{
    public class WalkRoadProp : AbstractProp
    {
        [SerializeField]
        private GameObject buoy;
        
        public override bool CanInteract()
        {
            return gameManager.inventoryManager.UsingCurrently == ResourceType.Buoy;
        }

        public override void AttemptNeutralize()
        {
            BuoyProp bo = Instantiate(buoy, new Vector3(transform.position.x - 2, transform.position.y, -1),
                new Quaternion(0, 0, 0, 0)).GetComponent<BuoyProp>();
            
            bo.SetAsPlayerPlaced();
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; } 
    }
}