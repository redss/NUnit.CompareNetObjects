using KellermanSoftware.CompareNetObjects;
using NUnit.Framework.Constraints;

namespace NUnit.CompareNetObjects
{
    public class IsDeeplyEqualConstraint : Constraint
    {
        private CompareLogic _compareLogic = new CompareLogic(DefaultCompareLogic.DefaultComparisonConfig);

        private ComparisonResult _comparisonResult;

        private readonly object _expectedValue;

        public IsDeeplyEqualConstraint(object expectedValue)
        {
            _expectedValue = expectedValue;
        }

        public override bool Matches(object actualValue)
        {
            actual = actualValue;

            _comparisonResult = _compareLogic.Compare(actualValue, _expectedValue);

            return _comparisonResult.AreEqual;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            if (_comparisonResult != null)
            {
                writer.Write(_comparisonResult.DifferencesString);
            }
        }

        public IsDeeplyEqualConstraint WithComparisonConfig(ComparisonConfig comparisonConfig)
        {
            // TODO: Test.

            _compareLogic = new CompareLogic(comparisonConfig);
            
            return this;
        }
    }
}