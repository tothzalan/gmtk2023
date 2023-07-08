using System;

namespace PropScripts
{
    public class CollectibleBuoy : AbstractProp
    {
        [NonSerialized]
        public bool isPlacedByPlayer;
        public override bool CanInteract()
        {
            return !isPlacedByPlayer;
        }

        public override void AttemptNeutralize()
        {
            if (isPlacedByPlayer)
                return;
            // here add to resources
            
            FinalizeNeutralization();
        }

        public override int MoneyToRemove { get; } = 0;
        public override int ToxicityDifference { get; } = 0;
        public override int ScoreDifference { get; } = 20;
    }
}