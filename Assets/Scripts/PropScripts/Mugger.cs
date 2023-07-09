using Enums;
using UnityEngine;

namespace PropScripts
{
    public class Mugger : AbstractProp
    {
        [SerializeField] private GameObject police;

        private Animator animator;
        private static readonly int Chased = Animator.StringToHash("Chased");
    
        public override int MoneyToRemove { get { return 20; } }
        public override int ToxicityDifference { get { return 5; } }
        public override int ScoreDifference { get { return -20; } }

        protected override void TriggerStart()
        {
            animator = gameObject.GetComponent<Animator>();
        }

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
        }
    }
}
