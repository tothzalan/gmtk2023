namespace PropScripts
{
    public class DealerProp : AbstractProp
    {
        public override bool CanInteract()
        {
            
        }

        public override void AttemptNeutralize()
        {
            throw new System.NotImplementedException();
        }

        public override int MoneyToRemove { get; } = 50;
        public override int ToxicityDifference { get; } = 20;
        public override int ScoreDifference { get; } = -50;
    }
}