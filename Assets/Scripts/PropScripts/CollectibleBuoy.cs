using System;
using UnityEngine;

namespace PropScripts
{
    public class CollectibleBuoy : AbstractProp
    {
        [NonSerialized]
        public bool isPlacedByPlayer;
        private Animator anim;
        private static readonly int PickedUp = Animator.StringToHash("PickedUp");

        public override bool CanInteract()
        {
            return !isPlacedByPlayer;
        }

        protected override void TriggerStart(){
            anim = gameObject.GetComponent<Animator>();
        }

        public override void AttemptNeutralize()
        {
            if (isPlacedByPlayer)
                return;
            
            // here add to resources
            BuoyResource.GetInstance().AddAmount(1);
            mapGenerator.buoyCount++;
            anim.SetBool("PickedUp", true);
        }

        public override int MoneyToRemove { get; } = 0;
        public override int ToxicityDifference { get; } = 0;
        public override int ScoreDifference { get; } = 20;
    }
}