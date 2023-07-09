namespace PropScripts
{
    public class PubStore : AbstractStoreScript
    {

        public override int MoneyToRemove { get; } = 10;
        public override int ToxicityDifference { get; } = 10;
        public override int ScoreDifference { get; } = -30;
    }
}