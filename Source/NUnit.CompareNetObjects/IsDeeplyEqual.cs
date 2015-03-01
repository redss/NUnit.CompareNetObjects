namespace NUnit.CompareNetObjects
{
    public static class IsDeeplyEqual
    {
        public static IsDeeplyEqualConstraint To(object expected)
        {
            return new IsDeeplyEqualConstraint(expected);
        }
    }
}