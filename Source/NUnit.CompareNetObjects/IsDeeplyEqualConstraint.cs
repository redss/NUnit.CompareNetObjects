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

        public IsDeeplyEqualConstraint WithComparisonConfig(ComparisonConfig comparisonConfig)
        {
            // TODO: Test.
            _compareLogic = new CompareLogic(comparisonConfig);            
            return this;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            _comparisonResult = _compareLogic.Compare(actual, _expectedValue);
            Description = _comparisonResult.DifferencesString;

            var result = new ConstraintResult(this, actual, _comparisonResult.AreEqual);
            return result;
        }
    }
}