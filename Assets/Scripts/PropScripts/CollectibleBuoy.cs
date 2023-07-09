using System;
using UnityEngine;

namespace PropScripts
{
    public class CollectibleBuoy : AbstractProp
    {
        [NonSerialized]
        public bool isPlacedByPlayer;
        private Animator anim;
        private Collider2D collider;
        private static readonly int PickedUp = Animator.StringToHash("PickedUp");

        public override bool CanInteract()
        {
            return base.CanInteract() && !isPlacedByPlayer;
        }

        protected override void TriggerStart(){
            anim = gameObject.GetComponent<Animator>();
            collider = gameObject.GetComponent<BoxCollider2D>();
        }

        public void SetAsPlayerPlaced()
        {
            isPlacedByPlayer = true;
            collider.isTrigger = false;
        }

        public override void AttemptNeutralize()
        {
            if (isPlacedByPlayer)
                return;
            
            // here add to resources
            BuoyResource.GetInstance().AddAmount(1);
            anim.SetBool(PickedUp, true);
        }

        public override int MoneyToRemove { get; } = 0;
        public override int ToxicityDifference { get; } = 0;
        public override int ScoreDifference { get; } = 20;
    }
}