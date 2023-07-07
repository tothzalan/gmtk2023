namespace PropScripts
{
    public class SlipperySignProp : AbstractProp
    {
        public override void AttemptNeutralize()
        {
            throw new System.NotImplementedException();
        }

        public override int MoneyDifference { get; }
        public override int ToxicityDifference { get; }
    }
}