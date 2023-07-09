using UnityEngine;

namespace PropScripts
{
    public class BlackoutProp : AbstractProp
    {
        private Animator animator;
        private static readonly int Collect = Animator.StringToHash("Collect");

        protected override void TriggerStart()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        public override bool CanInteract()
        {
            return true;
        }

        public override void AttemptNeutralize()
        {
            
            BlackoutResource.GetInstance().AddAmount(1);
            animator.SetTrigger(Collect);
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; } = 50;
    }
}