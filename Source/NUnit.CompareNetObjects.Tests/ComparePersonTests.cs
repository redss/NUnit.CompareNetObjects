using NUnit.Framework;

namespace NUnit.CompareNetObjects.Tests
{
    class ComparePersonTests
    {
        private Person _firstPerson;
        private Person _secondPerson;

        [SetUp]
        public void SetUp()
        {
            _firstPerson = PersonFactory.CreateSamplePerson();
            _secondPerson = PersonFactory.CreateSamplePerson();
        }

        [Test]
        public void Can_Compare_Two_Objects()
        {
            Assert.That(ExcersiseSystem, Throws.Nothing);
        }

        [Test]
        public void Throws_Exception_When_Property_Is_Different()
        {
            _secondPerson.Name = "Bob";

            var exception = Assert.Throws<AssertionException>(ExcersiseSystem);

            Assert.That(exception.Message, Is.StringContaining("Expected.Name != Actual.Name"));
        }

        [Test]
        public void Throws_Exception_When_Nested_Object_Is_Different()
        {
            _secondPerson.Address.City = "Katowice";

            var exception = Assert.Throws<AssertionException>(ExcersiseSystem);

            Assert.That(exception.Message, Is.StringContaining("Expected.Address.City != Actual.Address.City"));
        }

        [Test]
        public void Throws_Exception_When_Array_Size_Is_Differenr()
        {
            _secondPerson.Skills = new [] { _firstPerson.Skills[0] };

            var exception = Assert.Throws<AssertionException>(ExcersiseSystem);

            Assert.That(exception.Message, Is.StringContaining("Expected.Skills.Count != Actual.Skills.Count"));
        }

        [Test]
        public void Throws_Exception_When_Array_Item_Is_Different()
        {
            _secondPerson.Skills[0].Name = "Bazzinga";

            var exception = Assert.Throws<AssertionException>(ExcersiseSystem);

            Assert.That(exception.Message, Is.StringContaining("Expected.Skills[0].Name != Actual.Skills[0].Name"));
        }

        [Test]
        public void Throws_Exception_When_Second_Object_Is_Of_Different_Type()
        {
            var exception = Assert.Throws<AssertionException>(() =>
                Assert.That(_firstPerson, IsDeeplyEqual.To("Hello")));

            Assert.That(exception.Message, Is.StringContaining("Different Types"));
        }

        [Test]
        public void Throws_Exception_When_Second_Object_Is_Null()
        {
            _secondPerson = null;

            var exception = Assert.Throws<AssertionException>(ExcersiseSystem);

            Assert.That(exception.Message, Is.StringContaining("Expected != Actual"));
        }

        [Test]
        public void Can_Compare_Null_Objects()
        {
            _firstPerson = null;
            _secondPerson = null;

            Assert.That(ExcersiseSystem, Throws.Nothing);
        }

        [Test]
        public void Can_Find_Multiple_Differences()
        {
            _secondPerson.Name = "Thomas";
            _secondPerson.Level = Level.Baby;

            var exception = Assert.Throws<AssertionException>(ExcersiseSystem);

            Assert.That(exception.Message, Is.StringContaining("Expected.Name != Actual.Name"));
            Assert.That(exception.Message, Is.StringContaining("Expected.Level != Actual.Level"));
        }

        // TODO: Test dictionary

        private void ExcersiseSystem()
        {
            Assert.That(_firstPerson, IsDeeplyEqual.To(_secondPerson));
        }
    }
}