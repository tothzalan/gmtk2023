using System;
using UnityEngine;
using Enums;

namespace PropScripts
{
    public class SlipperySignProp : AbstractProp
    {
        private Animator animator;
        private static readonly int IsDestroyed = Animator.StringToHash("IsDestroyed");

        protected override void TriggerStart()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        public override void AttemptNeutralize()
        {
            animator.SetBool(IsDestroyed, true);
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; } = -50;
    }
}