using UnityEngine;

namespace PropScripts
{
    public class BeerProp : AbstractProp
    {
        private Animator animator;
        private static readonly int Delete = Animator.StringToHash("Delete");

        protected override void TriggerStart()
        {
            animator = gameObject.GetComponent<Animator>();
            transform.Rotate(0, 0, new System.Random().Next(360));
        }

        public override void AttemptNeutralize()
        {
            animator.SetTrigger(Delete);
        }

        public override void ExecuteInteraction()
        {
            base.ExecuteInteraction();
            animator.SetTrigger(Delete);
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; } = 20;
        public override int ScoreDifference { get; } = -50;
    }
}