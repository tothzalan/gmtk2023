namespace PropScripts
{
    public class SlipperySignProp : AbstractProp
    {
        public bool hasRemoved;
        public override bool CanInteract()
        {
            return !hasRemoved;
        }

        public override void AttemptNeutralize()
        {
            hasRemoved = true;
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; } = -50;
    }
}