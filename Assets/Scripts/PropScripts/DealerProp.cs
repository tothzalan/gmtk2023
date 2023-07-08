using Enums;

namespace PropScripts
{
    public class DealerProp : AbstractProp
    {
        public override bool CanInteract()
        {
            return gameManager.inventoryManager.UsingCurrently == ResourceType.Police;
        }

        public override void AttemptNeutralize()
        {
            
        }

        public override int MoneyToRemove { get; } = 50;
        public override int ToxicityDifference { get; } = 20;
        public override int ScoreDifference { get; } = -50;
    }
}