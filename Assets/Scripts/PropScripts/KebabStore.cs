namespace PropScripts
{
    public class KebabStore : AbstractStoreScript
    {
        public override int MoneyToRemove { get; } = 10;
        public override int ToxicityDifference { get; } = -30;
        public override int ScoreDifference { get; } = 50;
    }
}