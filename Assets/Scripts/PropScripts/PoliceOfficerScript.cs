using System;
using UnityEngine;

namespace PropScripts
{
    public class PoliceOfficerScript : AbstractProp
    {
        [NonSerialized]
        public bool isPlacedByPlayer;

        private Rigidbody2D rigidBody;
        private Animator animator;
        private static readonly int ChaseTrigger = Animator.StringToHash("ChaseTrigger");
        private static readonly int Collected = Animator.StringToHash("Collected");

        public override bool CanInteract()
        {
            return !isPlacedByPlayer;
        }

        protected override void TriggerStart()
        {
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            if (isPlacedByPlayer)
            {
                rigidBody.velocity = new Vector2(2.0f * (1 + gameManager.SpeedMultiplier), 0);
                animator.SetTrigger(ChaseTrigger);
            }
        }

        public override void AttemptNeutralize()
        {
            if (isPlacedByPlayer)
                return;
            
            // here add to resources
            PoliceResource.GetInstance().AddAmount(1);
            animator.SetTrigger(Collected);
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; } = 20;

    }
}
