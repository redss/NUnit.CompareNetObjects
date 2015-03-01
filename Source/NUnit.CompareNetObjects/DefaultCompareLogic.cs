using KellermanSoftware.CompareNetObjects;

namespace NUnit.CompareNetObjects
{
    public static class DefaultCompareLogic
    {
        public static ComparisonConfig DefaultComparisonConfig { get; set; }

        static DefaultCompareLogic()
        {
            DefaultComparisonConfig = new ComparisonConfig
            {
                Caching = false,
                MaxStructDepth = 5,
                MaxDifferences = 10
            };
        }
    }
}